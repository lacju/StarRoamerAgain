﻿#pragma strict
 
 public var Boundary : int = 50;
 public var speed : int = 5;
 
 private var theScreenWidth : int;
 private var theScreenHeight : int;
 
 function Start() 
 {
     theScreenWidth = Screen.width;
     theScreenHeight = Screen.height;
 }
 
 function Update() 
 {
     if (Input.mousePosition.x > theScreenWidth - Boundary)
     {
         transform.position.x += speed * Time.deltaTime;
     }
     
     if (Input.mousePosition.x < 0 + Boundary)
     {
         transform.position.x -= speed * Time.deltaTime;
     }
     
     if (Input.mousePosition.y > theScreenHeight - Boundary)
     {
         transform.position.y += speed * Time.deltaTime;
     }
     
     if (Input.mousePosition.y < 0 + Boundary)
     {
         transform.position.y -= speed * Time.deltaTime;
     }
     
 }    
 
 function OnGUI() 
 {
     GUI.Box( Rect( (Screen.width / 2) - 140, 5, 280, 25 ), "Mouse Position = " + Input.mousePosition );
     GUI.Box( Rect( (Screen.width / 2) - 70, Screen.height - 30, 140, 25 ), "Mouse X = " + Input.mousePosition.x );
     GUI.Box( Rect( 5, (Screen.height / 2) - 12, 140, 25 ), "Mouse Y = " + Input.mousePosition.y );
 }