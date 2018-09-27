using System;
using System.Collections.Generic;

namespace GestionClinic_LIB 
{
  public class   clsvitamine 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
  //***Listes***
  public List<clsvitamine> listes(){
 return clsMetier.GetInstance().getAllClsvitamine();
}
 public  List<clsvitamine>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsvitamine(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsvitamine(this);
 }
 public  int  update(clsvitamine varscls){
 return clsMetier.GetInstance().updateClsvitamine(varscls);
 }
 public  int  delete(clsvitamine varscls){
 return clsMetier.GetInstance().deleteClsvitamine(varscls);
 }
  //***Le constructeur par defaut***
  public    clsvitamine() 
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
