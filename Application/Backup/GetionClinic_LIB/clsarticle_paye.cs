using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
 public class clsarticle_paye
 {
  //***Les variables globales***
 private int   id ;
 private int   id_paiement ;
 private int   id_article ;
 private string   designation ;
 private string designation_classe;

  //***Listes***
 public List<clsarticle_paye> listes()
 {
     return clsMetier.GetInstance().getAllClsarticle_paye();
 }
 public List<clsarticle_paye> listes(string criteria)
 {
     return clsMetier.GetInstance().getAllClsarticle_paye(criteria);
 }
 public int  inserts(){
 return clsMetier.GetInstance().insertClsarticle_paye(this);
 }
 public  int  update(clsarticle_paye varscls){
 return clsMetier.GetInstance().updateClsarticle_paye(varscls);
 }
 public  int  delete(clsarticle_paye varscls){
 return clsMetier.GetInstance().deleteClsarticle_paye(varscls);
 }
  //***Le constructeur par defaut***
  public    clsarticle_paye() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}

 //***Accesseur de id_malade***
 public  int   Id_paiement {

get { return id_paiement; } 
set { id_paiement = value; }
}
//***Accesseur de id_article***
public int Id_article
{
  get { return id_article; }
  set { id_article = value; }
}
  //***Accesseur de conjoin***
 public  string   Designation {

get { return designation; } 
set { designation = value; }
}
  //***Accesseur de designation_classe***
 public string Designation_classe
 {
     get { return designation_classe; }
     set { designation_classe = value; }
 }
 public override string ToString()
 {
     return Designation;
 }
} //***fin class

} //***fin namespace
