using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clstarifavance 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
 private double?  montant ;
 private string designationComplete;

  //***Listes***
  public List<clstarifavance> listes(){
 return clsMetier.GetInstance().getAllClstarifavance();
}
 public  List<clstarifavance>   listes(string criteria){
 return clsMetier.GetInstance().getAllClstarifavance(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClstarifavance(this);
 }
 public  int  update(clstarifavance varscls){
 return clsMetier.GetInstance().updateClstarifavance(varscls);
 }
 public  int  delete(clstarifavance varscls){
 return clsMetier.GetInstance().deleteClstarifavance(varscls);
 }
  //***Le constructeur par defaut***
  public    clstarifavance() 
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
  //***Accesseur de montant***
 public  double ?   Montant {

get { return montant; } 
set { montant = value; }
}
 public string DesignationComplete
 {
     get { return designationComplete; }
     set { designationComplete = value; }
 }

 public override string ToString()
 {
     return DesignationComplete;
 }
} //***fin class

} //***fin namespace
