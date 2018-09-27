using System;
using System.Collections.Generic;

 namespace  GestionClinic_LIB 
{
  public class   clsexamengynecoobsetrical 
{
  //***Les variables globales***
 private int   id ;
 private int?  hu ;
 private int?  presentation ;
 private int?  bcf ;
 private string   contractionuterine ;
 private string   mfa ;
 private string   exauspeculum ;
 private string   colaspect ;
 private int?  tvcolefface ;
 private int?  tvcoldilate ;
 private string   pochedeeaux ;
 private DateTime?  dateheureruptrurecole ;
 private string   aspectduliquide ;
 private string   degreengagement ;
 private string   appreciationdubassin ;
 private int   id_consultationprenatal ;
  //***Listes***
  public List<clsexamengynecoobsetrical> listes(){
 return clsMetier.GetInstance().getAllClsexamengynecoobsetrical();
}
 public  List<clsexamengynecoobsetrical>   listes(string criteria){
 return clsMetier.GetInstance().getAllClsexamengynecoobsetrical(criteria);
 }
 public  int  inserts(){
 return clsMetier.GetInstance().insertClsexamengynecoobsetrical(this);
 }
 public  int  update(clsexamengynecoobsetrical varscls){
 return clsMetier.GetInstance().updateClsexamengynecoobsetrical(varscls);
 }
 public  int  delete(clsexamengynecoobsetrical varscls){
 return clsMetier.GetInstance().deleteClsexamengynecoobsetrical(varscls);
 }
  //***Le constructeur par defaut***
  public    clsexamengynecoobsetrical() 
{
}

  //***Accesseur de id***
 public  int   Id {

get { return id; } 
set { id = value; }
}
  //***Accesseur de hu***
 public  int ?   Hu {

get { return hu; } 
set { hu = value; }
}
  //***Accesseur de presentation***
 public  int ?   Presentation {

get { return presentation; } 
set { presentation = value; }
}
  //***Accesseur de bcf***
 public  int ?   Bcf {

get { return bcf; } 
set { bcf = value; }
}
  //***Accesseur de contractionuterine***
 public  string   Contractionuterine {

get { return contractionuterine; } 
set { contractionuterine = value; }
}
  //***Accesseur de mfa***
 public  string   Mfa {

get { return mfa; } 
set { mfa = value; }
}
  //***Accesseur de exauspeculum***
 public  string   Exauspeculum {

get { return exauspeculum; } 
set { exauspeculum = value; }
}
  //***Accesseur de colaspect***
 public  string   Colaspect {

get { return colaspect; } 
set { colaspect = value; }
}
  //***Accesseur de tvcolefface***
 public  int ?   Tvcolefface {

get { return tvcolefface; } 
set { tvcolefface = value; }
}
  //***Accesseur de tvcoldilate***
 public  int ?   Tvcoldilate {

get { return tvcoldilate; } 
set { tvcoldilate = value; }
}
  //***Accesseur de pochedeeaux***
 public  string   Pochedeeaux {

get { return pochedeeaux; } 
set { pochedeeaux = value; }
}
  //***Accesseur de dateheureruptrurecole***
 public  DateTime ?   Dateheureruptrurecole {

get { return dateheureruptrurecole; } 
set { dateheureruptrurecole = value; }
}
  //***Accesseur de aspectduliquide***
 public  string   Aspectduliquide {

get { return aspectduliquide; } 
set { aspectduliquide = value; }
}
  //***Accesseur de degreengagement***
 public  string   Degreengagement {

get { return degreengagement; } 
set { degreengagement = value; }
}
  //***Accesseur de appreciationdubassin***
 public  string   Appreciationdubassin {

get { return appreciationdubassin; } 
set { appreciationdubassin = value; }
}
  //***Accesseur de id_consultationprenatal***
 public  int   Id_consultationprenatal {

get { return id_consultationprenatal; } 
set { id_consultationprenatal = value; }
}

} //***fin class

} //***fin namespace
