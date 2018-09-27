using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsairsante 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
  //***Listes***
  public List<clsairsante> listes(){
 return clsMetier.GetInstance().getAllClsairsante();
}
 public  List<clsairsante>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsairsante(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsairsante(this);
 }
 public  int  update(clsairsante varscls){
 return clsMetier.GetInstance().updateClsairsante(varscls);
 }
 public  int  delete(clsairsante varscls){
 return clsMetier.GetInstance().deleteClsairsante(varscls);
 }
  //***Le constructeur par defaut***
  public    clsairsante() 
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
