using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clstypesysteme 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
  //***Listes***
  public List<clstypesysteme> listes(){
 return clsMetier.GetInstance().getAllClstypesysteme();
}
 public  List<clstypesysteme>   listes(string criteria){
 return clsMetier.GetInstance().getAllClstypesysteme(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClstypesysteme(this);
 }
 public  int  update(clstypesysteme varscls){
 return clsMetier.GetInstance().updateClstypesysteme(varscls);
 }
 public  int  delete(clstypesysteme varscls){
 return clsMetier.GetInstance().deleteClstypesysteme(varscls);
 }
  //***Le constructeur par defaut***
  public    clstypesysteme() 
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
