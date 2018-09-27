
using System;
using System.Data;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsexamen 
{
  //***Les variables globales***
 //****private string schaine_conn*****
 private int   id ;
 private string   designation ;
 private int   id_typeexamen ;
 private double?  prix ;

  //***Listes***
  public List<clsexamen> listes(){
 return clsMetier.GetInstance().getAllClsexamen();
}
 public  List<clsexamen>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsexamen(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsexamen(this);
 }
 public  int  update(clsexamen varscls){
 return clsMetier.GetInstance().updateClsexamen(varscls);
 }
 public  int  delete(clsexamen varscls){
 return clsMetier.GetInstance().deleteClsexamen(varscls);
 }
  //***Le constructeur par defaut***
  public    clsexamen() 
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
  //***Accesseur de id_typeexamen***
 public  int   Id_typeexamen {

get { return id_typeexamen; } 
set { id_typeexamen = value; }
}
  //***Accesseur de prix***
 public  double ?   Prix {

get { return prix; } 
set { prix = value; }
}
 public override string ToString()
 {
     return Designation;
 }
} //***fin class

} //***fin namespace
