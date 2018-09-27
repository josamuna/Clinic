using System;
using System.Collections.Generic;

namespace GestionClinic_LIB 
{
  public class   clsperiode 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
  //***Listes***
  public List<clsperiode> listes(){
 return clsMetier.GetInstance().getAllClsperiode();
}
 public  List<clsperiode>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsperiode(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsperiode(this);
 }
 public  int  update(clsperiode varscls){
 return clsMetier.GetInstance().updateClsperiode(varscls);
 }
 public  int  delete(clsperiode varscls){
 return clsMetier.GetInstance().deleteClsperiode(varscls);
 }
  //***Le constructeur par defaut***
  public    clsperiode() 
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
