import oscP5.*;
import netP5.*;
// to use serial communication, you must import the serial library
import processing.serial.*;
// create a serial port variable

Serial myPort;
OscP5 oscP5;
NetAddress myRemoteLocation;
OscMessage oscMessage;

int hitWall = 0;


void setup(){
 size(300,300);
 frameRate(60);
 
  myPort = new Serial(this, Serial.list()[0], 115200);
 
 oscP5 = new OscP5(this, 57131);
 myRemoteLocation = new NetAddress("127.0.0.1", 57130);
 
 oscMessage = new OscMessage("/Button");
 
 
}

void draw(){
  background(0); 

}

void sendValue(OscMessage message) {
  println("send message" );
  //println(message);
  
  // Send our data over to Unity!
  oscP5.send(message, myRemoteLocation);

  oscMessage = new OscMessage("/Button");
}

void oscEvent(OscMessage theOscMessage) {
  if (theOscMessage.checkAddrPattern("/hitWall") == true) {      
    hitWall = theOscMessage.get(0).intValue(); 

    if (hitWall == 1) { 
       myPort.write('1');         //send a 1
       println("hit wall"); 
    }
    
    return;
  }
}
