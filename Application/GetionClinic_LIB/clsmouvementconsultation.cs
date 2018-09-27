
using System;
using System.Data;
using System.Collections.Generic;

namespace GestionClinic_LIB 
{
  public class   clsmouvementconsultation 
{
  //***Les variables globales***
 //****private string schaine_conn*****
 private int   id ;
 private DateTime?  date ;
 private int   id_consultation ;
 private string   plainte ;
 private string   symptome ;
 private string   diagnostics ;
 private string   medicamentaprescrire ;
 private string conduite;
 private DateTime? dateEch;

  //***Listes***
  public List<clsmouvementconsultation> listes(){
 return clsMetier.GetInstance().getAllClsmouvementconsultation();
}
 public  List<clsmouvementconsultation>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsmouvementconsultation(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsmouvementconsultation(this);
 }
 public  int  update(clsmouvementconsultation varscls){
 return clsMetier.GetInstance().updateClsmouvementconsultation(varscls);
 }
 public  int  delete(clsmouvementconsultation varscls){
 return clsMetier.GetInstance().deleteClsmouvementconsultation(varscls);
 }
  //***Le constructeur par defaut***
  public    clsmouvementconsultation() 
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
  //***Accesseur de id_consultation***
 public  int   Id_consultation {

get { return id_consultation; } 
set { id_consultation = value; }
}
  //***Accesseur de plainte***
 public  string   Plainte {

get { return plainte; } 
set { plainte = value; }
}
  //***Accesseur de symptome***
 public  string   Symptome {

get { return symptome; } 
set { symptome = value; }
}
  //***Accesseur de diagnostics***
 public  string   Diagnostics {

get { return diagnostics; } 
set { diagnostics = value; }
}
  //***Accesseur de medicamentaprescrire***
 public  string   Medicamentaprescrire {

get { return medicamentaprescrire; } 
set { medicamentaprescrire = value; }
}

 public string Conduite
 {
     get { return conduite; }
     set { conduite = value; }
 }

 public DateTime? DateEch
 {
     get { return dateEch; }
     set { dateEch = value; }
 }


} //***fin class

} //***fin namespace
