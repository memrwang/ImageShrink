//
//  CustomContentView.swift
//  ImageShrink
//
//  Created by wang on 2023/7/29.
//
import Cocoa

class CustomContentView: NSView {
    var backgroundImage: NSImage?
    
    override func draw(_ dirtyRect: NSRect) {
        super.draw(dirtyRect)
        
        if let backgroundImage = backgroundImage {
            backgroundImage.draw(in: bounds)
        }
    }
}
