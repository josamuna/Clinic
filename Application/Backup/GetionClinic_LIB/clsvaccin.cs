using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsvaccin 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
  //***Listes***
  public List<clsvaccin> listes(){
 return clsMetier.GetInstance().getAllClsvaccin();
}
 public  List<clsvaccin>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsvaccin(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsvaccin(this);
 }
 public  int  update(clsvaccin varscls){
 return clsMetier.GetInstance().updateClsvaccin(varscls);
 }
 public  int  delete(clsvaccin varscls){
 return clsMetier.GetInstance().deleteClsvaccin(varscls);
 }
  //***Le constructeur par defaut***
  public    clsvaccin() 
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
