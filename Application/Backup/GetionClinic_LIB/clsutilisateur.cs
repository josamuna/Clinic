using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
     public class clsutilisateur:clsagent
{
  //***Les variables globales***
 private int   id ;
 private int   id_agent ;
 private string   nomuser ;
 private string   motpass ;
 private string schema_user;
 private string droits;
 private bool?  activation ;
  //***Listes***
  public new List<clsutilisateur> listes(){
 return clsMetier.GetInstance().getAllClsutilisateur();
}
 public  new List<clsutilisateur>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsutilisateur(criteria);
 }
 public  new int  inserts(){
 return clsMetier.GetInstance().insertClsutilisateur(this);
 }
 public  int  update(clsutilisateur varscls){
 return clsMetier.GetInstance().updateClsutilisateur(varscls);
 }
 public  int  delete(clsutilisateur varscls){
 return clsMetier.GetInstance().deleteClsutilisateur(varscls);
 }
  //***Le constructeur par defaut***
  public    clsutilisateur() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de id_personne***
 public  int   Id_agent {

get { return id_agent; } 
set { id_agent = value; }
}
  //***Accesseur de nomuser***
 public  string   Nomuser {

get { return nomuser; } 
set { nomuser = value; }
}
  //***Accesseur de motpass***
 public  string   Motpass {

get { return motpass; } 
set { motpass = value; }
}
  //***Accesseur de activation***
 public  bool ?   Activation {

get { return activation; } 
set { activation = value; }
}
 //***Accesseur de schema_user***
 public string Schema_user
 {
     get { return schema_user; }
     set { schema_user = value; }
 }
 //***Accesseur de droits***
 public string Droits
 {
     get { return droits; }
     set { droits = value; }
 }
} //***fin class

} //***fin namespace
