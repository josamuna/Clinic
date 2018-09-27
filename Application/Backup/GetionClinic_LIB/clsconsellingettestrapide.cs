using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsconsellingettestrapide 
{
  //***Les variables globales***
 private int   id ;
 private string   rvtregine ;
 private DateTime?  datedebutttt ;
 private DateTime?  datedebuttravail ;
 private DateTime?  heure ;
 private int   id_consultationprenatal ;
  //***Listes***
  public List<clsconsellingettestrapide> listes(){
 return clsMetier.GetInstance().getAllClsconsellingettestrapide();
}
 public  List<clsconsellingettestrapide>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsconsellingettestrapide(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsconsellingettestrapide(this);
 }
 public  int  update(clsconsellingettestrapide varscls){
 return clsMetier.GetInstance().updateClsconsellingettestrapide(varscls);
 }
 public  int  delete(clsconsellingettestrapide varscls){
 return clsMetier.GetInstance().deleteClsconsellingettestrapide(varscls);
 }
  //***Le constructeur par defaut***
  public    clsconsellingettestrapide() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de rvtregine***
 public  string   Rvtregine {

get { return rvtregine; } 
set { rvtregine = value; }
}
  //***Accesseur de datedebutttt***
 public  DateTime ?   Datedebutttt {

get { return datedebutttt; } 
set { datedebutttt = value; }
}
  //***Accesseur de datedebuttravail***
 public  DateTime ?   Datedebuttravail {

get { return datedebuttravail; } 
set { datedebuttravail = value; }
}
  //***Accesseur de heure***
 public  DateTime ?   Heure {

get { return heure; } 
set { heure = value; }
}
  //***Accesseur de id_consultationprenatal***
 public  int   Id_consultationprenatal {

get { return id_consultationprenatal; } 
set { id_consultationprenatal = value; }
}

} //***fin class

} //***fin namespace
