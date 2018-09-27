using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsbloc 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
 private int?  id_service ;
  //***Listes***
  public List<clsbloc> listes(){
 return clsMetier.GetInstance().getAllClsbloc();
}
 public  List<clsbloc>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsbloc(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsbloc(this);
 }
 public  int  update(clsbloc varscls){
 return clsMetier.GetInstance().updateClsbloc(varscls);
 }
 public  int  delete(clsbloc varscls){
 return clsMetier.GetInstance().deleteClsbloc(varscls);
 }
  //***Le constructeur par defaut***
  public    clsbloc() 
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
  //***Accesseur de id_service***
 public  int ?   Id_service {

get { return id_service; } 
set { id_service = value; }
}

} //***fin class

} //***fin namespace
