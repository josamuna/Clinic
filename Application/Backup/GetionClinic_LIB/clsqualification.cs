using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsqualification 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
  //***Listes***
  public List<clsqualification> listes(){
 return clsMetier.GetInstance().getAllClsqualification();
}
 public  List<clsqualification>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsqualification(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsqualification(this);
 }
 public  int  update(clsqualification varscls){
 return clsMetier.GetInstance().updateClsqualification(varscls);
 }
 public  int  delete(clsqualification varscls){
 return clsMetier.GetInstance().deleteClsqualification(varscls);
 }
  //***Le constructeur par defaut***
  public    clsqualification() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de designation***
 public  string   Designation {

get { return designation; } 
set { designation = value; }
}

} //***fin class

} //***fin namespace
