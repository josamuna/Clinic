using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsrendezvous 
{
  //***Les variables globales***
 private int   id ;
 private DateTime?  date ;
 private string   observation ;
 private int?  id_maladeenconsultationpostnatal ;
  //***Listes***
  public List<clsrendezvous> listes(){
 return clsMetier.GetInstance().getAllClsrendezvous();
}
 public  List<clsrendezvous>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsrendezvous(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsrendezvous(this);
 }
 public  int  update(clsrendezvous varscls){
 return clsMetier.GetInstance().updateClsrendezvous(varscls);
 }
 public  int  delete(clsrendezvous varscls){
 return clsMetier.GetInstance().deleteClsrendezvous(varscls);
 }
  //***Le constructeur par defaut***
  public    clsrendezvous() 
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
  //***Accesseur de observation***
 public  string   Observation {

get { return observation; } 
set { observation = value; }
}
  //***Accesseur de id_maladeenconsultationpostnatal***
 public  int ?   Id_maladeenconsultationpostnatal {

get { return id_maladeenconsultationpostnatal; } 
set { id_maladeenconsultationpostnatal = value; }
}

} //***fin class

} //***fin namespace
