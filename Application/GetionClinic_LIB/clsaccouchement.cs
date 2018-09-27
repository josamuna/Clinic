using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsaccouchement 
{
  //***Les variables globales***
 private int   id ;
 private string   lieu ;
 private string   traitement ;
 private int?  bcg ;
 private int?  vat ;
 private int?  degree ;
 private DateTime?  date ;
 private int   id_maladegrosse ;
 private int   id_typeaccouchement ;
 private string etatpaiement;
 private int id_de_typeaccouchement;
 private string designationComplete;
 private string designation_typeAccouchement;
 private double prix_de_typeaccouchement;

  //***Listes***
  public List<clsaccouchement> listes(){
 return clsMetier.GetInstance().getAllClsaccouchement();
}
 public  List<clsaccouchement>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsaccouchement(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsaccouchement(this);
 }
 public  int  update(clsaccouchement varscls){
 return clsMetier.GetInstance().updateClsaccouchement(varscls);
 }
 public  int  delete(clsaccouchement varscls){
 return clsMetier.GetInstance().deleteClsaccouchement(varscls);
 }
  //***Le constructeur par defaut***
  public    clsaccouchement() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de lieu***
 public  string   Lieu {

get { return lieu; } 
set { lieu = value; }
}
  //***Accesseur de traitement***
 public  string   Traitement {

get { return traitement; } 
set { traitement = value; }
}
  //***Accesseur de bcg***
 public  int ?   Bcg {

get { return bcg; } 
set { bcg = value; }
}
  //***Accesseur de vat***
 public  int ?   Vat {

get { return vat; } 
set { vat = value; }
}
  //***Accesseur de degree***
 public  int ?   Degree {

get { return degree; } 
set { degree = value; }
}
  //***Accesseur de date***
 public  DateTime ?   Date {

get { return date; } 
set { date = value; }
}
  //***Accesseur de id_maladegrosse***
 public  int   Id_maladegrosse {

get { return id_maladegrosse; } 
set { id_maladegrosse = value; }
}
  //***Accesseur de id_typeaccouchement***
 public  int   Id_typeaccouchement {

get { return id_typeaccouchement; } 
set { id_typeaccouchement = value; }
}
 //***Accesseur de Etatpaiement***
 public string Etatpaiement
 {
     get { return etatpaiement; }
     set { etatpaiement = value; }
 }

 //***Accesseur de Id_de_typeaccouchement***
 public int Id_de_typeaccouchement
 {
     get { return id_de_typeaccouchement; }
     set { id_de_typeaccouchement = value; }
 }
 //***Accesseur de designation***
 public string DesignationComplete
 {

     get { return designationComplete; }
     set { designationComplete = value; }
 }
 public override string ToString()
 {
     return DesignationComplete;
 }
 //***Accesseur de prix_de_typeaccouchement***
 public double Prix_de_typeaccouchement
 {
     get { return prix_de_typeaccouchement; }
     set { prix_de_typeaccouchement = value; }
 }
 //***Accesseur de designation_typeAccouchement***
 public string Designation_typeAccouchement
 {
     get { return designation_typeAccouchement; }
     set { designation_typeAccouchement = value; }
 }
} //***fin class

} //***fin namespace
