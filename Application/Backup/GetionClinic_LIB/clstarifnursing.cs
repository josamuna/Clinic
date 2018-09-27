using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clstarifnursing 
{
  //***Les variables globales***
 private int   id ;
 private string   designation ;
 private double?  montant ;
 private string designationComplete;
 private int id_de_dossiernursing;

  //***Listes***
  public List<clstarifnursing> listes(){
 return clsMetier.GetInstance().getAllClstarifnursing();
}
 public  List<clstarifnursing>   listes(string criteria){
 return clsMetier.GetInstance().getAllClstarifnursing(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClstarifnursing(this);
 }
 public  int  update(clstarifnursing varscls){
 return clsMetier.GetInstance().updateClstarifnursing(varscls);
 }
 public  int  delete(clstarifnursing varscls){
 return clsMetier.GetInstance().deleteClstarifnursing(varscls);
 }
  //***Le constructeur par defaut***
  public    clstarifnursing() 
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
 //***Accesseur de id_de_dossiernursing***
 public int Id_de_dossiernursing
 {
     get { return id_de_dossiernursing; }
     set { id_de_dossiernursing = value; }
 }
 public override string ToString()
 {
     return DesignationComplete;
 }
} //***fin class

} //***fin namespace
