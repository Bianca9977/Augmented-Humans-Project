import oscP5.*;
import netP5.*;
// to use serial communication, you must import the serial library
import processing.serial.*;
// create a serial port variable

Serial myPort;
OscP5 oscP5;
NetAddress myRemoteLocation;

int hitWall = 0, direction = 0, distance = 0;


void setup(){
 size(300,300);
 frameRate(60);
 
 // myPort = new Serial(this, Serial.list()[0], 115200);
 
 oscP5 = new OscP5(this, 57131);
 myRemoteLocation = new NetAddress("127.0.0.1", 57130);
}

void draw(){
  background(0); 
}

void oscEvent(OscMessage theOscMessage) {
  if (theOscMessage.checkAddrPattern("/hitWall") == true) {      
    hitWall = theOscMessage.get(0).intValue(); 

    if (hitWall == 1) { 
       //myPort.write('1');         //send a 1
       println("hit wall"); 
    }
    
    return;
  }
  
  if (theOscMessage.checkAddrPattern("/Direction") == true) {      
    direction = theOscMessage.get(0).intValue();  //2 - turn left; 3 - turn right; 4 - go straight

    if (direction == 2) { 
      // myPort.write('2');         
       println("turn left"); 
    } else if (direction == 3) {
     //  myPort.write('3');         
       println("turn right"); 
    } else if (direction == 4) {
     //  myPort.write('4');         
       println("go straight"); 
    }
    
    return;
  }
  
   if (theOscMessage.checkAddrPattern("/Distance") == true) {      
    distance = theOscMessage.get(0).intValue();  //80 - medium; 110 - high

    if (distance == 80) { 
      // myPort.write('80');         
       println("medium"); 
    } else if (distance == 110) {
     //  myPort.write('110');         
       println("high"); 
    } 
    
    return;
  }
}
