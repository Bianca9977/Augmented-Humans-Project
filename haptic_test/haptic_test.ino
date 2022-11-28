/*
Date: 5/2021
Author: Elias Santistevan @ SparkFun Electronics
Writing vibration values via I2C to vibrate the motor. 

This vibrates *extremely* vigurously, adhere the motor to something or it will
produce a fault and stop functioning. 

*/

#include <Wire.h>
#include "Haptic_Driver.h"

Haptic_Driver hapDrive;
#define NUMBER_OF_SENSORS 2

int event = 0; 
char val; // Data received from the serial port

void setup(){

  Serial.begin(115200);
  Wire.begin();

  if( !hapDrive.begin())
    Serial.println("Could not communicate with Haptic Driver.");
  else
    Serial.println("Qwiic Haptic Driver DA7280 found!");

  if( !hapDrive.defaultMotor() ) 
    Serial.println("Could not set default settings.");

  // Frequency tracking is done by the IC to ensure that the motor is hitting
  // its resonant frequency. I found that restricting the PCB (squeezing)
  // raises an error which stops operation because it can not reach resonance.
  // I disable here to avoid this error. 
  /*hapDrive.enableFreqTrack(false);

  Serial.println("Setting I2C Operation.");
  hapDrive.setOperationMode(DRO_MODE);
  Serial.println("Ready."); 

  delay(1000);*/

  //Initialize all the sensors
  for (int x = 0 ; x < NUMBER_OF_SENSORS ; x++)
  {
    
    enableMuxPort(x); //Tell mux to connect to port X

    hapDrive.begin();
    hapDrive.setOperationMode(DRO_MODE);

   
    Serial.println("Driver start");

    disableMuxPort(x);
  }

}

void loop(){
  // If uploading often the Haptic Driver IC will throw a fault. Let's
  // clear that error (0x10), just in case.
  //event = hapDrive.getIrqEvent();
  //Serial.print("Interrupt: ");
  //Serial.println(event, HEX);
  //Serial.println("Clearing event.");
  //hapDrive.clearIrq(event);

  // Max value is 127 with acceleration on (default).
 // hapDrive.setVibrate(25);
  //delay(500); 
  //hapDrive.setVibrate(0); 
  //delay(500);

  //start from here 28/11
   /* if (Serial.available()) 
    { // If data is available to read,
      val = Serial.read(); // read it and store it in val
    }
    
    if (val == '1') 
    { 
      hapDrive.setVibrate(90);
      delay(500); 
      hapDrive.setVibrate(0);
      val = 0; 
    } 

   delay(1000); */

  /*for (byte x = 0 ; x < NUMBER_OF_SENSORS ; x++)
    {
      enableMuxPort(x); //Tell mux to connect to this port, and this port only

      if (hapDrive.begin())
      {
          event = hapDrive.getIrqEvent();
          hapDrive.clearIrq(event);
          hapDrive.setVibrate(90);
          delay(500); 
          hapDrive.setVibrate(0);

          Serial.println("vibrate");


      }

      disableMuxPort(x); //Tell mux to disconnect from this port
        delay(2000);
  }*/
enableMuxPort(0); //Tell mux to connect to this port, and this port only

      if (hapDrive.begin())
      {
          event = hapDrive.getIrqEvent();
          hapDrive.clearIrq(event);
          hapDrive.setVibrate(90);
          delay(500); 
          hapDrive.setVibrate(0);

          Serial.println("vibrate");


      }

      disableMuxPort(0); //Tell mux to disconnect from this port
        delay(1000);
}
