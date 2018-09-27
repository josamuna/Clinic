using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsevacuation 
{
  //***Les variables globales***
 private int   id ;
 private int   id_malade ;
 private DateTime?  dateevacuation ;
 private string   motif ;
  //***Listes***
  public List<clsevacuation> listes(){
 return clsMetier.GetInstance().getAllClsevacuation();
}
 public  List<clsevacuation>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsevacuation(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsevacuation(this);
 }
 public  int  update(clsevacuation varscls){
 return clsMetier.GetInstance().updateClsevacuation(varscls);
 }
 public  int  delete(clsevacuation varscls){
 return clsMetier.GetInstance().deleteClsevacuation(varscls);
 }
  //***Le constructeur par defaut***
  public    clsevacuation() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de id_malade***
 public  int   Id_malade {

get { return id_malade; } 
set { id_malade = value; }
}
  //***Accesseur de dateevacuation***
 public  DateTime ?   Dateevacuation {

get { return dateevacuation; } 
set { dateevacuation = value; }
}
  //***Accesseur de motif***
 public  string   Motif {

get { return motif; } 
set { motif = value; }
}

} //***fin class

} //***fin namespace
