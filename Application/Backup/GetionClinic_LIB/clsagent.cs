using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsagent : clspersonne
{
  //***Les variables globales***
 private int   id ;
 private int   id_personne ;
 private int   id_categorieagent ;
 private int   id_fonction ;
 private int   id_qualification ;
 private int id_service;

 private string   matricule ;
 private string   grade ;
 private DateTime?  dateangagement = DateTime.Today;
 private string   numeroinss ;
  //***Listes***
  public new List<clsagent> listes(){
 return clsMetier.GetInstance().getAllClsagent();
}
 public  new List<clsagent>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsagent(criteria);
 }
 public  new int  inserts(){
 return clsMetier.GetInstance().insertClsagent(this);
 }
 public  int  update(clsagent varscls){
 return clsMetier.GetInstance().updateClsagent(varscls);
 }
 public  int  delete(clsagent varscls){
 return clsMetier.GetInstance().deleteClsagent(varscls);
 }
  //***Le constructeur par defaut***
  public    clsagent() 
{
}

  //***Accesseur de id***
 public  int   IdAgent {

get { return id; } 
set { id = value; }
}
  //***Accesseur de id_personne***
 public  int   Id_personne {

get { return id_personne; } 
set { id_personne = value; }
}
  //***Accesseur de id_categorieagent***
 public  int   Id_categorieagent {

get { return id_categorieagent; } 
set { id_categorieagent = value; }
}
  //***Accesseur de id_fonction***
 public  int   Id_fonction {

get { return id_fonction; } 
set { id_fonction = value; }
}
  //***Accesseur de id_qualification***
 public  int   Id_qualification {

get { return id_qualification; } 
set { id_qualification = value; }
}
 //***Accesseur de id_service***
 public int Id_service{
 get { return id_service; }
 set { id_service = value; }
 }
  //***Accesseur de matricule***
 public  string   Matricule {

get { return matricule; } 
set { matricule = value; }
}
  //***Accesseur de grade***
 public  string   Grade {

get { return grade; } 
set { grade = value; }
}
  //***Accesseur de dateangagement***
 public  DateTime ?   Dateangagement {

get { return dateangagement; } 
set { dateangagement = value; }
}
  //***Accesseur de numeroinss***
 public  string   Numeroinss {

get { return numeroinss; } 
set { numeroinss = value; }
}

} //***fin class

} //***fin namespace
