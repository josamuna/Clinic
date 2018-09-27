using System;
using System.Data;
using System.Collections.Generic;

namespace GestionClinic_LIB 
{
  public class   clsdossierconsultationgynecologique 
{
  //***Les variables globales***
 //****private string schaine_conn*****
 private int   id ;
 private DateTime?  date ;
 private int   id_malade ;
 private int id_agent;
 private int id_tarifconsultationgynecologique;
 private string designationComplete;
 private string   etatpaiement ;

  //***Listes***
  public List<clsdossierconsultationgynecologique> listes(){
 return clsMetier.GetInstance().getAllClsdossierconsultationgynecologique();
}
 public  List<clsdossierconsultationgynecologique>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsdossierconsultationgynecologique(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsdossierconsultationgynecologique(this);
 }
 public  int  update(clsdossierconsultationgynecologique varscls){
 return clsMetier.GetInstance().updateClsdossierconsultationgynecologique(varscls);
 }
 public  int  delete(clsdossierconsultationgynecologique varscls){
 return clsMetier.GetInstance().deleteClsdossierconsultationgynecologique(varscls);
 }
  //***Le constructeur par defaut***
  public    clsdossierconsultationgynecologique() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de date***
 public  DateTime ?   Date {

get { return date; } 
set { date = value; }
}
  //***Accesseur de id_malade***
 public  int   Id_malade {

get { return id_malade; } 
set { id_malade = value; }
}
  //***Accesseur de etatpaiement***
 public  string   Etatpaiement {

get { return etatpaiement; } 
set { etatpaiement = value; }
}
 //***Accesseur de id_tarifconsultationgynecologique***
 public int Id_tarifconsultationgynecologique
 {
     get { return id_tarifconsultationgynecologique; }
     set { id_tarifconsultationgynecologique = value; }
 }

 public int Id_agent
 {
     get { return id_agent; }
     set { id_agent = value; }
 }

 public override string ToString()
 {
     return DesignationComplete.ToString();
 }

 public string DesignationComplete
 {
     get { return designationComplete; }
     set { designationComplete = value; }
 }
} //***fin class

} //***fin namespace