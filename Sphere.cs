#ifndef IMPLICIT_SPHERE_H
#define IMPLICIT_SPHERE_H
#include "implicitmodulebase.h"
#include <cmath>

namespace NoiseLibrary
{
class CImplicitSphere : public CImplicitModuleBase
{
    public:
    CImplicitSphere();
    CImplicitSphere(double radius, double cx, double cy, double cz);
    CImplicitSphere(double radius, double cx, double cy, CImplicitModuleBase * cz);
    CImplicitSphere(double radius, double cx, CImplicitModuleBase * cy, double cz);
    CImplicitSphere(double radius, double cx, CImplicitModuleBase * cy, CImplicitModuleBase * cz);
    CImplicitSphere(double radius, CImplicitModuleBase * cx, double cy, double cz);
    CImplicitSphere(double radius, CImplicitModuleBase * cx, double cy, CImplicitModuleBase * cz);
    CImplicitSphere(double radius, CImplicitModuleBase * cx, CImplicitModuleBase * cy, double cz);
    CImplicitSphere(double radius, CImplicitModuleBase * cx, CImplicitModuleBase * cy, CImplicitModuleBase * cz);
    CImplicitSphere(CImplicitModuleBase * radius, double cx, double cy, double cz);
    CImplicitSphere(CImplicitModuleBase * radius, double cx, double cy, CImplicitModuleBase * cz);
    CImplicitSphere(CImplicitModuleBase * radius, double cx, CImplicitModuleBase * cy, double cz);
    CImplicitSphere(CImplicitModuleBase * radius, double cx, CImplicitModuleBase * cy, CImplicitModuleBase * cz);
    CImplicitSphere(CImplicitModuleBase * radius, CImplicitModuleBase * cx, double cy, double cz);
    CImplicitSphere(CImplicitModuleBase * radius, CImplicitModuleBase * cx, double cy, CImplicitModuleBase * cz);
    CImplicitSphere(CImplicitModuleBase * radius, CImplicitModuleBase * cx, CImplicitModuleBase * cy, double cz);
    CImplicitSphere(CImplicitModuleBase * radius, CImplicitModuleBase * cx, CImplicitModuleBase * cy, CImplicitModuleBase * cz);

    ~CImplicitSphere();
    void setCenter(double cx,double cy,double cz=0,double cw=0,double cu=0,double cv=0);
    void setCenterX(double cx);
    void setCenterY(double cy);
    void setCenterZ(double cz);
    void setCenterW(double cw);
    void setCenterU(double cu);
    void setCenterV(double cv);
    void setCenterX(CImplicitModuleBase * cx);
    void setCenterY(CImplicitModuleBase * cy);
    void setCenterZ(CImplicitModuleBase * cz);
    void setCenterW(CImplicitModuleBase * cw);
    void setCenterU(CImplicitModuleBase * cu);
    void setCenterV(CImplicitModuleBase * cv);

    void setRadius(double r);
    void setRadius(CImplicitModuleBase * r);

    double get(double x, double y);
    double get(double x, double y, double z);
    double get(double x, double y, double z, double w);
    double get(double x, double y, double z, double w, double u, double v);

    protected:
    CScalarParameter m_cx, m_cy, m_cz, m_cw, m_cu, m_cv;
    CScalarParameter m_radius;

};
};

#endif
#include "implicitsphere.h"

namespace NoiseLibrary
{
    CImplicitSphere::CImplicitSphere() : CImplicitModuleBase(), m_cx(0.0), m_cy(0.0), m_cz(0.0), m_cw(0.0), m_cu(0.0), m_cv(0.0), m_radius(1.0){}

    CImplicitSphere::CImplicitSphere(double radius, double cx, double cy, double cz) : CImplicitModuleBase(), m_cx(cx), m_cy(cy), m_cz(cz), m_cw(0.0), m_cu(0.0), m_cv(0.0), m_radius(radius){}
    CImplicitSphere::CImplicitSphere(double radius, double cx, double cy, CImplicitModuleBase * cz) : CImplicitModuleBase(), m_cx(cx), m_cy(cy), m_cz(cz), m_cw(0.0), m_cu(0.0), m_cv(0.0), m_radius(radius){}
    CImplicitSphere::CImplicitSphere(double radius, double cx, CImplicitModuleBase * cy, double cz) : CImplicitModuleBase(), m_cx(cx), m_cy(cy), m_cz(cz), m_cw(0.0), m_cu(0.0), m_cv(0.0), m_radius(radius){}
    CImplicitSphere::CImplicitSphere(double radius, double cx, CImplicitModuleBase * cy, CImplicitModuleBase * cz) : CImplicitModuleBase(), m_cx(cx), m_cy(cy), m_cz(cz), m_cw(0.0), m_cu(0.0), m_cv(0.0), m_radius(radius){}
    CImplicitSphere::CImplicitSphere(double radius, CImplicitModuleBase * cx, double cy, double cz) : CImplicitModuleBase(), m_cx(cx), m_cy(cy), m_cz(cz), m_cw(0.0), m_cu(0.0), m_cv(0.0), m_radius(radius){}
    CImplicitSphere::CImplicitSphere(double radius, CImplicitModuleBase * cx, double cy, CImplicitModuleBase * cz) : CImplicitModuleBase(), m_cx(cx), m_cy(cy), m_cz(cz), m_cw(0.0), m_cu(0.0), m_cv(0.0), m_radius(radius){}
    CImplicitSphere::CImplicitSphere(double radius, CImplicitModuleBase * cx, CImplicitModuleBase * cy, double cz) : CImplicitModuleBase(), m_cx(cx), m_cy(cy), m_cz(cz), m_cw(0.0), m_cu(0.0), m_cv(0.0), m_radius(radius){}
    CImplicitSphere::CImplicitSphere(double radius, CImplicitModuleBase * cx, CImplicitModuleBase * cy, CImplicitModuleBase * cz) : CImplicitModuleBase(), m_cx(cx), m_cy(cy), m_cz(cz), m_cw(0.0), m_cu(0.0), m_cv(0.0), m_radius(radius){}
    CImplicitSphere::CImplicitSphere(CImplicitModuleBase * radius, double cx, double cy, double cz) : CImplicitModuleBase(), m_cx(cx), m_cy(cy), m_cz(cz), m_cw(0.0), m_cu(0.0), m_cv(0.0), m_radius(radius){}
    CImplicitSphere::CImplicitSphere(CImplicitModuleBase * radius, double cx, double cy, CImplicitModuleBase * cz) : CImplicitModuleBase(), m_cx(cx), m_cy(cy), m_cz(cz), m_cw(0.0), m_cu(0.0), m_cv(0.0), m_radius(radius){}
    CImplicitSphere::CImplicitSphere(CImplicitModuleBase * radius, double cx, CImplicitModuleBase * cy, double cz) : CImplicitModuleBase(), m_cx(cx), m_cy(cy), m_cz(cz), m_cw(0.0), m_cu(0.0), m_cv(0.0), m_radius(radius){}
    CImplicitSphere::CImplicitSphere(CImplicitModuleBase * radius, double cx, CImplicitModuleBase * cy, CImplicitModuleBase * cz) : CImplicitModuleBase(), m_cx(cx), m_cy(cy), m_cz(cz), m_cw(0.0), m_cu(0.0), m_cv(0.0), m_radius(radius){}
    CImplicitSphere::CImplicitSphere(CImplicitModuleBase * radius, CImplicitModuleBase * cx, double cy, double cz) : CImplicitModuleBase(), m_cx(cx), m_cy(cy), m_cz(cz), m_cw(0.0), m_cu(0.0), m_cv(0.0), m_radius(radius){}
    CImplicitSphere::CImplicitSphere(CImplicitModuleBase * radius, CImplicitModuleBase * cx, double cy, CImplicitModuleBase * cz) : CImplicitModuleBase(), m_cx(cx), m_cy(cy), m_cz(cz), m_cw(0.0), m_cu(0.0), m_cv(0.0), m_radius(radius){}
    CImplicitSphere::CImplicitSphere(CImplicitModuleBase * radius, CImplicitModuleBase * cx, CImplicitModuleBase * cy, double cz) : CImplicitModuleBase(), m_cx(cx), m_cy(cy), m_cz(cz), m_cw(0.0), m_cu(0.0), m_cv(0.0), m_radius(radius){}
    CImplicitSphere::CImplicitSphere(CImplicitModuleBase * radius, CImplicitModuleBase * cx, CImplicitModuleBase * cy, CImplicitModuleBase * cz) : CImplicitModuleBase(), m_cx(cx), m_cy(cy), m_cz(cz), m_cw(0.0), m_cu(0.0), m_cv(0.0), m_radius(radius){}

    CImplicitSphere::~CImplicitSphere(){}

    void CImplicitSphere::setCenter(double cx,double cy,double cz,double cw,double cu,double cv)
    {
        m_cx=cx; m_cy=cy; m_cz=cz; m_cw=cw; m_cu=cu; m_cv=cv;
    }
    void CImplicitSphere::setCenterX(double cx){m_cx.set(cx);}
    void CImplicitSphere::setCenterY(double cy){m_cy.set(cy);}
    void CImplicitSphere::setCenterZ(double cz){m_cz.set(cz);}
    void CImplicitSphere::setCenterW(double cw){m_cw.set(cw);}
    void CImplicitSphere::setCenterU(double cu){m_cu.set(cu);}
    void CImplicitSphere::setCenterV(double cv){m_cv.set(cv);}
    void CImplicitSphere::setCenterX(CImplicitModuleBase * cx){m_cx.set(cx);}
    void CImplicitSphere::setCenterY(CImplicitModuleBase * cy){m_cy.set(cy);}
    void CImplicitSphere::setCenterZ(CImplicitModuleBase * cz){m_cz.set(cz);}
    void CImplicitSphere::setCenterW(CImplicitModuleBase * cw){m_cw.set(cw);}
    void CImplicitSphere::setCenterU(CImplicitModuleBase * cu){m_cu.set(cu);}
    void CImplicitSphere::setCenterV(CImplicitModuleBase * cv){m_cv.set(cv);}
    void CImplicitSphere::setRadius(double r)
    {
        m_radius.set(r);
    }
    void CImplicitSphere::setRadius(CImplicitModuleBase * r)
    {
        m_radius.set(r);
    }

    double CImplicitSphere::get(double x, double y)
    {
        double dx=x-m_cx.get(x,y), dy=y-m_cy.get(x,y);
        double len=sqrt(dx*dx+dy*dy);
        double radius=m_radius.get(x,y);
        double i=(radius-len)/radius;
        if(i<0) i=0;
        if(i>1) i=1;

        return i;
    }

    double CImplicitSphere::get(double x, double y, double z)
    {
        double dx=x-m_cx.get(x,y,z), dy=y-m_cy.get(x,y,z), dz=z-m_cz.get(x,y,z);
        double len=sqrt(dx*dx+dy*dy+dz*dz);
        double radius=m_radius.get(x,y,z);
        double i=(radius-len)/radius;
        if(i<0) i=0;
        if(i>1) i=1;

        return i;
    }

    double CImplicitSphere::get(double x, double y, double z, double w)
    {
        double dx=x-m_cx.get(x,y,z,w), dy=y-m_cy.get(x,y,z,w), dz=z-m_cz.get(x,y,z,w), dw=w-m_cw.get(x,y,z,w);
        double len=sqrt(dx*dx+dy*dy+dz*dz+dw*dw);
        double radius=m_radius.get(x,y,z,w);
        double i=(radius-len)/radius;
        if(i<0) i=0;
        if(i>1) i=1;

        return i;
    }

    double CImplicitSphere::get(double x, double y, double z, double w, double u, double v)
    {
        double dx=x-m_cx.get(x,y,z,w,u,v), dy=y-m_cy.get(x,y,z,w,u,v), dz=z-m_cz.get(x,y,z,w,u,v), dw=w-m_cw.get(x,y,z,w,u,v),
            du=u-m_cu.get(x,y,z,w,u,v), dv=v-m_cv.get(x,y,z,w,u,v);
        double len=sqrt(dx*dx+dy*dy+dz*dz+dw*dw+du*du+dv*dv);
        double radius=m_radius.get(x,y,z,w,u,v);
        double i=(radius-len)/radius;
        if(i<0) i=0;
        if(i>1) i=1;

        return i;
    }
};
