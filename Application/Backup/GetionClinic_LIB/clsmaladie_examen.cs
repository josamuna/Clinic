using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsmaladie_examen 
{
  //***Les variables globales***
 private int   id ;
 private int   id_operation_laboratoire ;
 private int   id_examen ;
 private int   id_maladie ;
 private DateTime?  date ;
  //***Listes***
  public List<clsmaladie_examen> listes(){
 return clsMetier.GetInstance().getAllClsmaladie_examen();
}
 public  List<clsmaladie_examen>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsmaladie_examen(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsmaladie_examen(this);
 }
 public  int  update(clsmaladie_examen varscls){
 return clsMetier.GetInstance().updateClsmaladie_examen(varscls);
 }
 public  int  delete(clsmaladie_examen varscls){
 return clsMetier.GetInstance().deleteClsmaladie_examen(varscls);
 }
  //***Le constructeur par defaut***
  public    clsmaladie_examen() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de id_operation_laboratoire***
 public  int   Id_operation_laboratoire {

get { return id_operation_laboratoire; } 
set { id_operation_laboratoire = value; }
}
  //***Accesseur de id_examen***
 public  int   Id_examen {

get { return id_examen; } 
set { id_examen = value; }
}
  //***Accesseur de id_maladie***
 public  int   Id_maladie {

get { return id_maladie; } 
set { id_maladie = value; }
}
  //***Accesseur de date***
 public  DateTime ?   Date {

get { return date; } 
set { date = value; }
}

} //***fin class

} //***fin namespace
