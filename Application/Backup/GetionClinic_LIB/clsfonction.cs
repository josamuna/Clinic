using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsfonction 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
  //***Listes***
  public List<clsfonction> listes(){
 return clsMetier.GetInstance().getAllClsfonction();
}
 public  List<clsfonction>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsfonction(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsfonction(this);
 }
 public  int  update(clsfonction varscls){
 return clsMetier.GetInstance().updateClsfonction(varscls);
 }
 public  int  delete(clsfonction varscls){
 return clsMetier.GetInstance().deleteClsfonction(varscls);
 }
  //***Le constructeur par defaut***
  public    clsfonction() 
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
