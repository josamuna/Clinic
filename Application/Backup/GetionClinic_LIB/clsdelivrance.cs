using System;
using System.Collections.Generic;

namespace GestionClinic_LIB 
{
  public class   clsdelivrance 
{
  //***Les variables globales***
 private int   id ;
 private string   ocyticine10uim ;
 private bool?  tractioncontroleducordon ;
 private bool?  massageuterinapredelivrance ;
 private DateTime?  delivranceartificiel ;
 private string   plancenta ;
 private string   aspect ;
 private string   membranes ;
 private string   hemoragie ;
 private DateTime?  date ;
 private int   id_maladegrosse ;
  //***Listes***
  public List<clsdelivrance> listes(){
 return clsMetier.GetInstance().getAllClsdelivrance();
}
 public  List<clsdelivrance>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsdelivrance(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsdelivrance(this);
 }
 public  int  update(clsdelivrance varscls){
 return clsMetier.GetInstance().updateClsdelivrance(varscls);
 }
 public  int  delete(clsdelivrance varscls){
 return clsMetier.GetInstance().deleteClsdelivrance(varscls);
 }
  //***Le constructeur par defaut***
  public    clsdelivrance() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de ocyticine10uim***
 public  string   Ocyticine10uim {

get { return ocyticine10uim; } 
set { ocyticine10uim = value; }
}
  //***Accesseur de tractioncontroleducordon***
 public  bool ?   Tractioncontroleducordon {

get { return tractioncontroleducordon; } 
set { tractioncontroleducordon = value; }
}
  //***Accesseur de massageuterinapredelivrance***
 public  bool ?   Massageuterinapredelivrance {

get { return massageuterinapredelivrance; } 
set { massageuterinapredelivrance = value; }
}
  //***Accesseur de delivranceartificiel***
 public  DateTime ?   Delivranceartificiel {

get { return delivranceartificiel; } 
set { delivranceartificiel = value; }
}
  //***Accesseur de plancenta***
 public  string   Plancenta {

get { return plancenta; } 
set { plancenta = value; }
}
  //***Accesseur de aspect***
 public  string   Aspect {

get { return aspect; } 
set { aspect = value; }
}
  //***Accesseur de membranes***
 public  string   Membranes {

get { return membranes; } 
set { membranes = value; }
}
  //***Accesseur de hemoragie***
 public  string   Hemoragie {

get { return hemoragie; } 
set { hemoragie = value; }
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
} //***fin class

} //***fin namespace
