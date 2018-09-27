using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsgroupesanguin 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
  //***Listes***
  public List<clsgroupesanguin> listes(){
 return clsMetier.GetInstance().getAllClsgroupesanguin();
}
 public  List<clsgroupesanguin>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsgroupesanguin(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsgroupesanguin(this);
 }
 public  int  update(clsgroupesanguin varscls){
 return clsMetier.GetInstance().updateClsgroupesanguin(varscls);
 }
 public  int  delete(clsgroupesanguin varscls){
 return clsMetier.GetInstance().deleteClsgroupesanguin(varscls);
 }
  //***Le constructeur par defaut***
  public    clsgroupesanguin() 
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
