using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsperiodevaccination 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
  //***Listes***
  public List<clsperiodevaccination> listes(){
 return clsMetier.GetInstance().getAllClsperiodevaccination();
}
 public  List<clsperiodevaccination>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsperiodevaccination(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsperiodevaccination(this);
 }
 public  int  update(clsperiodevaccination varscls){
 return clsMetier.GetInstance().updateClsperiodevaccination(varscls);
 }
 public  int  delete(clsperiodevaccination varscls){
 return clsMetier.GetInstance().deleteClsperiodevaccination(varscls);
 }
  //***Le constructeur par defaut***
  public    clsperiodevaccination() 
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
