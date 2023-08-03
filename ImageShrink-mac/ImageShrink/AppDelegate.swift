//
//  AppDelegate.swift
//  ImageShrink
//
//  Created by along on 2023/7/22.
//

import Cocoa

@main
class AppDelegate: NSObject, NSApplicationDelegate, NSTableViewDataSource, NSTableViewDelegate, NSWindowDelegate, NSDraggingDestination {

    @IBOutlet var window: NSWindow!

    @IBOutlet weak var tableView: NSTableView!
    
    @IBOutlet weak var OutputTextField: NSTextField!
    
    @IBOutlet weak var QualityComboBox: NSComboBox!
    
    @IBOutlet weak var SavePathTextField: NSTextField!
    
    @IBOutlet weak var TaskTableView: NSScrollView!
    
    @IBOutlet weak var ISOutput: NSTextFieldCell!
    
    
    var data: [[String]] = []
    
    func applicationDidFinishLaunching(_ aNotification: Notification) {
        // Insert code here to initialize your application
        
        // 设置窗口背景颜色为白色
        window.backgroundColor = NSColor.white
        
        // 将窗口注册为拖放目标
        window.registerForDraggedTypes([NSPasteboard.PasteboardType.fileURL])
        
        window.delegate = self
        
        tableView.dataSource = self
        tableView.delegate = self
        
        TaskTableViewIsHidden() // 隐藏任务列表
        
        if let desktopURL = getDesktopPath() {
            ISOutput.stringValue = desktopURL.path+"/ISOutput/"
        }
    }

    func applicationWillTerminate(_ aNotification: Notification) {
        // Insert code here to tear down your application
    }

    func applicationSupportsSecureRestorableState(_ app: NSApplication) -> Bool {
        return true
    }
    
    func applicationShouldTerminateAfterLastWindowClosed(_ sender: NSApplication) -> Bool {
        return true
    }
    
    // 如果列表任务空，隐藏表格视图
    func TaskTableViewIsHidden(){
        if tableView.numberOfRows == 0 {
            TaskTableView.isHidden = true
        } else {
            TaskTableView.isHidden = false
        }
    }
    
    // 获取桌面路径
    func getDesktopPath() -> URL? {
        let fileManager = FileManager.default
        guard let desktopURL = fileManager.urls(for: .desktopDirectory, in: .userDomainMask).first else {
            return nil
        }
        return desktopURL
    }
    
    // 当拖放操作进入窗口时调用
    func draggingEntered(_ sender: NSDraggingInfo) -> NSDragOperation {
        return .copy
    }

    // 当拖放操作在窗口上移动时调用
    func draggingUpdated(_ sender: NSDraggingInfo) -> NSDragOperation {
        return .copy
    }

    // 当拖放操作离开窗口时调用
    func draggingExited(_ sender: NSDraggingInfo?) {
        
    }

    // 当拖放操作完成时调用
    func performDragOperation(_ sender: NSDraggingInfo) -> Bool {
        let pasteboard = sender.draggingPasteboard
        if let fileURLs = pasteboard.readObjects(forClasses: [NSURL.self], options: nil) as? [NSURL] {
            for fileURL in fileURLs {
                let filePath = fileURL.path
                let fileName = fileURL.lastPathComponent
                if let filePath = filePath, let fileName = fileName {
                    // 检查文件类型
                    if let fileExtension = fileURL.pathExtension?.lowercased(),
                       ["jpg", "png", "gif", "jpeg"].contains(fileExtension) {
                        if let fileSize = self.getFileSize(filePath: filePath) {
                            let fileSizeString = fileSize
                            // 添加数据
                            self.data.append([filePath, "", fileName, fileSizeString, ""])
                        }
                    }
                }
            }
            // 重新加载数据
            self.tableView.reloadData()
            TaskTableViewIsHidden() // 显示任务列表
        }
        return true
    }
    
    func numberOfRows(in tableView: NSTableView) -> Int {
        return data.count
    }
    
    func tableView(_ tableView: NSTableView, viewFor tableColumn: NSTableColumn?, row: Int) -> NSView? {
        let columnId = tableColumn?.identifier.rawValue ?? ""
        let columnIndex = tableView.tableColumns.firstIndex(of: tableColumn!) ?? 0
        let cell = tableView.makeView(withIdentifier: NSUserInterfaceItemIdentifier(rawValue: columnId), owner: nil) as? NSTableCellView
        let rowData = data[row]
        cell?.textField?.stringValue = rowData[columnIndex]
        return cell
    }
    
    // 保存路径-浏览按钮
    @IBAction func SavePathBrowseButton(_ sender: Any) {
        let openPanel = NSOpenPanel()
        openPanel.canChooseFiles = false
        openPanel.canChooseDirectories = true
        openPanel.allowsMultipleSelection = false
        openPanel.canCreateDirectories = true // 允许创建新文件夹
        openPanel.begin { (result) in
            if result == NSApplication.ModalResponse.OK {
                if let url = openPanel.url {
                    // 保存路径后面没有/结尾需要加/
                    var SavePathValue = url.path
                    if !SavePathValue.hasSuffix("/") {
                        SavePathValue += "/"
                    }
                    self.SavePathTextField.stringValue = SavePathValue
                }
            }
        }
    }
    
    // 保存路径-打开访达
    @IBAction func OpenSavePathButton(_ sender: Any) {
        let workspace = NSWorkspace.shared
        let path = SavePathTextField.stringValue
        workspace.open(URL(fileURLWithPath: path))
    }
    
    // 添加按钮
    @IBAction func AddButton(_ sender: Any) {
        let openPanel = NSOpenPanel()
        openPanel.allowedFileTypes = ["jpg", "png", "gif", "jpeg"]
        openPanel.canChooseFiles = true
        openPanel.canChooseDirectories = false
        openPanel.allowsMultipleSelection = true
        
        openPanel.begin { (result) in
            if result == NSApplication.ModalResponse.OK {
                let urls = openPanel.urls
                for url in urls {
                    let filePath = url.path
                    let fileName = url.lastPathComponent
                    if let fileSize = self.getFileSize(filePath: filePath) {
                        let fileSizeString = fileSize
                        // 添加数据
                        self.data.append([filePath, "", fileName, fileSizeString, ""])
                    }
                }
                // 重新加载数据
                self.tableView.reloadData()
                // 显示任务列表
                self.TaskTableViewIsHidden()
            }
        }
    }
    
    // 清空按钮
    @IBAction func ClearButton(_ sender: Any) {
        // 清空表格全部行
        let numberOfRows = tableView.numberOfRows
            if numberOfRows > 0 {
                let indexSet = IndexSet(integersIn: 0..<numberOfRows)
                tableView.removeRows(at: indexSet, withAnimation: .effectFade)
            }
        data = [] // 清空数据
        TaskTableViewIsHidden() // 隐藏任务列表
    }
    
    // 开始按钮
    @IBAction func StartButton(_ sender: Any) {
        //输出目录
        let outputPath = OutputTextField.stringValue
        //图片质量
        let quality = QualityComboBox.stringValue
        //如果保存路径最后没有/加/
        let output = outputPath.last == "/" ? outputPath : outputPath + "/"
        
        OutputTextField.stringValue = output
        
        let fileManager = FileManager.default

        // 检查保存路径文件夹是否存在
        if !fileManager.fileExists(atPath: output) {
            do {
                // 创建文件夹
                try fileManager.createDirectory(atPath: output, withIntermediateDirectories: true, attributes: nil)
                // 文件夹创建成功
            } catch {
                // 创建文件夹失败
            }
        } else {
            // 文件夹已存在
        }
        
        for row in 0..<tableView.numberOfRows {
            if let sourceCellView = tableView.view(atColumn: 0, row: row, makeIfNecessary: false) as? NSTableCellView,
               let sourceValue = sourceCellView.textField?.stringValue,
               let fileNameCellView = tableView.view(atColumn: 2, row: row, makeIfNecessary: false) as? NSTableCellView,
               let fileNameValue = fileNameCellView.textField?.stringValue {
                // 图像压缩
                Compress(source: sourceValue, output: output, fileName: fileNameValue, quality: quality)
                
                // 压缩结束，更新完成状态
                if let cellView = tableView.view(atColumn: 1, row: row, makeIfNecessary: false) as? NSTableCellView {
                    if let textField = cellView.textField {
                        textField.stringValue = "✅" // 状态完成符合
                    }
                }
                
                // 压缩结束，获取压缩后的文件大小
                if let cellView = tableView.view(atColumn: 4, row: row, makeIfNecessary: false) as? NSTableCellView {
                    if let textField = cellView.textField {
                        if let fileSize = self.getFileSize(filePath: output+fileNameValue) {
                            let fileSizeString = fileSize
                            textField.stringValue = fileSizeString // 压缩后文件大小
                        }
                    }
                }
            }
        }
    }
    
    /// <summary>
    /// 压缩图片
    /// </summary>
    /// <param name="source">原文件位置</param>
    /// <param name="output">新文件位置</param>
    /// <param name="fileName">文件名</param>
    /// <param name="quality">图像质量，范围0-100</param>
    func Compress(source: String, output: String, fileName: String, quality: String){
        // 获取文件格式
        let fileURL = URL(fileURLWithPath: fileName)
        let fileExtension = fileURL.pathExtension.lowercased() // 将文件扩展名转换为小写
        // 获取app路径
        let bundlePath = Bundle.main.bundlePath
        
        if (fileExtension == "jpg" || fileExtension == "jpeg"){
            // 删除已存在的文件
            let fileManager = FileManager.default
            if fileManager.fileExists(atPath: output+fileName) {
                do {
                    try fileManager.removeItem(atPath: output+fileName)
                    // 删除成功
                } catch {
                    // 删除失败
                }
            }
            
            // 处理JPG文件
            let filePath = bundlePath + "/Contents/Resources/libs/jpegoptim"
            // 创建Process对象
            let process = Process()
            process.launchPath = filePath
            process.arguments = ["--max="+quality, source, "--dest="+output]
            process.launch()
            process.waitUntilExit()
            
        }else if (fileExtension == "png"){
            // 处理PNG文件
            let filePath = bundlePath + "/Contents/Resources/libs/pngquant"
            // 创建Process对象
            let process = Process()
            process.launchPath = filePath
            process.arguments = ["--force","--quality="+quality, source, "--output="+output+fileName]
            process.launch()
            process.waitUntilExit()
            
        }else if (fileExtension == "gif"){
            // 处理GIF文件
            let filePath = bundlePath + "/Contents/Resources/libs/gifski"
            // 创建Process对象
            let process = Process()
            process.launchPath = filePath
            process.arguments = ["--quality="+quality, source, "--output="+output+fileName]
            process.launch()
            process.waitUntilExit()
        }
    }
    
    // 获取文件大小
    func getFileSize(filePath: String) -> String? {
        do {
            let fileAttributes = try FileManager.default.attributesOfItem(atPath: filePath)
            if let fileSize = fileAttributes[FileAttributeKey.size] as? UInt64 {
                let byteCountFormatter = ByteCountFormatter()
                byteCountFormatter.allowedUnits = [.useBytes, .useKB, .useMB, .useGB]
                byteCountFormatter.countStyle = .file
                return byteCountFormatter.string(fromByteCount: Int64(fileSize))
            }
        } catch {
            print("Error: \(error)")
        }
        return nil
    }
    
    // 官网
    @IBAction func WebsiteClick(_ sender: Any) {
        if let url = URL(string: "http://ialong.cn") {
            NSWorkspace.shared.open(url)
        }
    }
}
