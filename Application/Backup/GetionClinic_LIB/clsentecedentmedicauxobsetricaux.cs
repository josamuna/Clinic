using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsentecedentmedicauxobsetricaux 
{
  //***Les variables globales***
 private int   id ;
 private int?  nombreenfantvivant ;
 private int?  nombreenfantmort ;
 private int?  nombreenfantmordnee ;
 private int?  mortavant7jour ;
 private DateTime?  datedernieraccouchement ;
 private int?  eutocine ;
 private int?  dynstocine ;
 private int?  nbrebebepoidssuperieura4 ;
 private int?  nbrebebepoidsinferieura4 ;
 private int?  nbregrossessemultiple ;
 private int   id_consultationprenatal ;
  //***Listes***
  public List<clsentecedentmedicauxobsetricaux> listes(){
 return clsMetier.GetInstance().getAllClsentecedentmedicauxobsetricaux();
}
 public  List<clsentecedentmedicauxobsetricaux>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsentecedentmedicauxobsetricaux(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsentecedentmedicauxobsetricaux(this);
 }
 public  int  update(clsentecedentmedicauxobsetricaux varscls){
 return clsMetier.GetInstance().updateClsentecedentmedicauxobsetricaux(varscls);
 }
 public  int  delete(clsentecedentmedicauxobsetricaux varscls){
 return clsMetier.GetInstance().deleteClsentecedentmedicauxobsetricaux(varscls);
 }
  //***Le constructeur par defaut***
  public    clsentecedentmedicauxobsetricaux() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de nombreenfantvivant***
 public  int ?   Nombreenfantvivant {

get { return nombreenfantvivant; } 
set { nombreenfantvivant = value; }
}
  //***Accesseur de nombreenfantmort***
 public  int ?   Nombreenfantmort {

get { return nombreenfantmort; } 
set { nombreenfantmort = value; }
}
  //***Accesseur de nombreenfantmordnee***
 public  int ?   Nombreenfantmordnee {

get { return nombreenfantmordnee; } 
set { nombreenfantmordnee = value; }
}
  //***Accesseur de mortavant7jour***
 public  int ?   Mortavant7jour {

get { return mortavant7jour; } 
set { mortavant7jour = value; }
}
  //***Accesseur de datedernieraccouchement***
 public  DateTime ?   Datedernieraccouchement {

get { return datedernieraccouchement; } 
set { datedernieraccouchement = value; }
}
  //***Accesseur de eutocine***
 public  int ?   Eutocine {

get { return eutocine; } 
set { eutocine = value; }
}
  //***Accesseur de dynstocine***
 public  int ?   Dynstocine {

get { return dynstocine; } 
set { dynstocine = value; }
}
  //***Accesseur de nbrebebepoidssuperieura4***
 public  int ?   Nbrebebepoidssuperieura4 {

get { return nbrebebepoidssuperieura4; } 
set { nbrebebepoidssuperieura4 = value; }
}
  //***Accesseur de nbrebebepoidsinferieura4***
 public  int ?   Nbrebebepoidsinferieura4 {

get { return nbrebebepoidsinferieura4; } 
set { nbrebebepoidsinferieura4 = value; }
}
  //***Accesseur de nbregrossessemultiple***
 public  int ?   Nbregrossessemultiple {

get { return nbregrossessemultiple; } 
set { nbregrossessemultiple = value; }
}
  //***Accesseur de id_consultationprenatal***
 public  int   Id_consultationprenatal {

get { return id_consultationprenatal; } 
set { id_consultationprenatal = value; }
}

} //***fin class

} //***fin namespace
