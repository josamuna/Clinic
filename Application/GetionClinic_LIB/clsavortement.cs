using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsavortement 
{
  //***Les variables globales***
 private int   id ;
 private DateTime?  date ;
 private int   id_maladegrosse ;
  //***Listes***
  public List<clsavortement> listes(){
 return clsMetier.GetInstance().getAllClsavortement();
}
 public  List<clsavortement>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsavortement(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsavortement(this);
 }
 public  int  update(clsavortement varscls){
 return clsMetier.GetInstance().updateClsavortement(varscls);
 }
 public  int  delete(clsavortement varscls){
 return clsMetier.GetInstance().deleteClsavortement(varscls);
 }
  //***Le constructeur par defaut***
  public    clsavortement() 
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
  //***Accesseur de id_maladegrosse***
 public  int   Id_maladegrosse {

get { return id_maladegrosse; } 
set { id_maladegrosse = value; }
}

} //***fin class

} //***fin namespace
