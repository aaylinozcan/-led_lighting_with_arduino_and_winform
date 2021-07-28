#define Buton 8
#define Led 10

void setup() {
  Serial.begin(9600);
  pinMode(Buton,INPUT);
  pinMode(Led,OUTPUT);
}

void loop() {
  if (Serial.available()){
    char gelen_bilgi = Serial.read();
    if(gelen_bilgi == '1'){
      digitalWrite(Led,HIGH);
      Serial.print("led open");
    }
    else if(gelen_bilgi == '0'){
      digitalWrite(Led,LOW);
      Serial.print("led close");
    }
  delay(100);
  }

  if(digitalRead(Buton) == HIGH){
    digitalWrite(Led,HIGH);
    Serial.print("led open");
  }
  else {
    digitalWrite(Led,LOW);
    Serial.print("led close");
  }
  delay(10);
}
