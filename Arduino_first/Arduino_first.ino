#include <Servo.h>
char Incoming_value;
Servo myservo;
int pos;
int hi;
int github;
void setup(){
  Serial.begin(9600);
  pinMode(13,OUTPUT);
  myservo.attach(7);
  }

void loop()
{
  if(Serial.available() > 0)
  {
    Incoming_value = Serial.read();
    Serial.print(Incoming_value);
    Serial.print ("\n");
    if(Incoming_value == '1' && pos != 90 ){
      digitalWrite(13, HIGH);
      for (pos = 10; pos <= 90; pos += 1){
        myservo.write(pos);              // tell servo to go to position in variable 'pos'
        delay(15); 
        }
      }
    
    else if (Incoming_value == '0' && pos != 10){
     
      digitalWrite(13,LOW);
      for (pos = 90; pos >= 10; pos -= 1){ // goes from 180 degrees to 0 degrees
    myservo.write(pos);              // tell servo to go to position in variable 'pos'
    delay(15);                       // waits 15ms for the servo to reach the position
  }
    
      }
      
  }
  }
