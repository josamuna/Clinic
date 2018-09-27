using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsmaladie 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
  //***Listes***
  public List<clsmaladie> listes(){
 return clsMetier.GetInstance().getAllClsmaladie();
}
 public  List<clsmaladie>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsmaladie(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsmaladie(this);
 }
 public  int  update(clsmaladie varscls){
 return clsMetier.GetInstance().updateClsmaladie(varscls);
 }
 public  int  delete(clsmaladie varscls){
 return clsMetier.GetInstance().deleteClsmaladie(varscls);
 }
  //***Le constructeur par defaut***
  public    clsmaladie() 
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
 public override string ToString()
 {
     return this.Designation;
 }

} //***fin class

} //***fin namespace
