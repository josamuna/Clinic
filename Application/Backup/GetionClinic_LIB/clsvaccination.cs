using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsvaccination 
{
  //***Les variables globales***
 private int   id ;
 private DateTime?  date ;
 private int   id_maladeenconsultationpostnatal ;
 private int   id_periodevaccination ;
 private int?  id_prise_vitamine ;
 private int?  id_vaccin ;
  //***Listes***
  public List<clsvaccination> listes(){
 return clsMetier.GetInstance().getAllClsvaccination();
}
 public  List<clsvaccination>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsvaccination(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsvaccination(this);
 }
 public  int  update(clsvaccination varscls){
 return clsMetier.GetInstance().updateClsvaccination(varscls);
 }
 public  int  delete(clsvaccination varscls){
 return clsMetier.GetInstance().deleteClsvaccination(varscls);
 }
  //***Le constructeur par defaut***
  public    clsvaccination() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de date***
 public  DateTime ?   Date {

get { return date; } 
set { date = value; }
}
  //***Accesseur de id_maladeenconsultationpostnatal***
 public  int   Id_maladeenconsultationpostnatal {

get { return id_maladeenconsultationpostnatal; } 
set { id_maladeenconsultationpostnatal = value; }
}
  //***Accesseur de id_periodevaccination***
 public  int   Id_periodevaccination {

get { return id_periodevaccination; } 
set { id_periodevaccination = value; }
}
  //***Accesseur de id_prise_vitamine***
 public  int ?   Id_prise_vitamine {

get { return id_prise_vitamine; } 
set { id_prise_vitamine = value; }
}
  //***Accesseur de id_vaccin***
 public  int ?   Id_vaccin {

get { return id_vaccin; } 
set { id_vaccin = value; }
}

} //***fin class

} //***fin namespace
