int sensor = 9;  //訊號線
int buzzer = 3;
int count = 0;
int average=0;

void setup() {                
  Serial.begin(9600); 
  pinMode(sensor, INPUT); 
  pinMode(buzzer, OUTPUT);
}

void loop() 
{
  int moving = digitalRead(sensor); //讀取D9是否有偵測到物體移動
  count++;
  average+=moving;
  if(count==10){
    if(average>=8){ //如果有物體移動
    digitalWrite(buzzer, HIGH);//有源蜂鳴器響起
    delay(250);
    digitalWrite(buzzer, LOW);  //有源蜂鳴器關閉
    delay(250);
    digitalWrite(buzzer, HIGH);//有源蜂鳴器響起
    delay(250);
    digitalWrite(buzzer, LOW);  //有源蜂鳴器關閉
    delay(250);
    moving=1;
  }
  else{
    digitalWrite(buzzer, LOW);
    delay(1000);
    moving=0;
  }
  String dataout = String ("{message: ");
  dataout = String(dataout + String(moving) + "}"); 
  Serial.println(dataout);
  count=0;
  average=0;
  }
  if(count!=0){
  delay(1000);
  }
}
