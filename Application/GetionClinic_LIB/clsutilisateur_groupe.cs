using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsutilisateur_groupe 
{
  //***Les variables globales***
 private int   id ;
 private int   id_utilisateur ;
 private int   id_groupe ;
  //***Listes***
  public List<clsutilisateur_groupe> listes(){
 return clsMetier.GetInstance().getAllClsutilisateur_groupe();
}
 public  List<clsutilisateur_groupe>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsutilisateur_groupe(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsutilisateur_groupe(this);
 }
 public  int  update(clsutilisateur_groupe varscls){
 return clsMetier.GetInstance().updateClsutilisateur_groupe(varscls);
 }
 public  int  delete(clsutilisateur_groupe varscls){
 return clsMetier.GetInstance().deleteClsutilisateur_groupe(varscls);
 }
  //***Le constructeur par defaut***
  public    clsutilisateur_groupe() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de id_periodevaccination***
 public  int   Id_utilisateur {

get { return id_utilisateur; } 
set { id_utilisateur = value; }
}
  //***Accesseur de id_prise_vitamine***
 public  int  Id_groupe {
 get { return id_groupe; }
 set { id_groupe = value; }
 }

} //***fin class

} //***fin namespace
