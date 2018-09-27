using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsintervention 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
 private double?  prix ;
 private int   id_bloc ;
 private int id_de_subit;
 private string designationConplete;

  //***Listes***
  public List<clsintervention> listes(){
 return clsMetier.GetInstance().getAllClsintervention();
}
 public  List<clsintervention>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsintervention(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsintervention(this);
 }
 public  int  update(clsintervention varscls){
 return clsMetier.GetInstance().updateClsintervention(varscls);
 }
 public  int  delete(clsintervention varscls){
 return clsMetier.GetInstance().deleteClsintervention(varscls);
 }
  //***Le constructeur par defaut***
  public    clsintervention() 
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
  //***Accesseur de prix***
 public  double ?   Prix {

get { return prix; } 
set { prix = value; }
}
  //***Accesseur de id_bloc***
 public  int   Id_bloc {

get { return id_bloc; } 
set { id_bloc = value; }
}
 //***Accesseur de designationComplete***
 public string DesignationConplete
 {
     get { return designationConplete; }
     set { designationConplete = value; }
 }
 public override string ToString()
 {
     return DesignationConplete;// return this.Designation + "=>" + this.Prix + " $US";
 }
 //***Accesseur de id_de_subit***
 public int Id_de_subit
 {
     get { return id_de_subit; }
     set { id_de_subit = value; }
 }
} //***fin class

} //***fin namespace
