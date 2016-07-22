#ifndef IMPLICIT_RGBADOTPRODUCT_H
#define IMPLICIT_RGBADOTPRODUCT_H
#include "implicitmodulebase.h"
#include "rgbamodulebase.h"

namespace NoiseLibrary
{
    class CImplicitRGBADotProduct : public CImplicitModuleBase
    {
        public:
        CImplicitRGBADotProduct();
        ~CImplicitRGBADotProduct();

        void setSource1(CRGBAModuleBase * m);
        void setSource1(SRGBA c);
        void setSource2(CRGBAModuleBase * m);
        void setSource2(SRGBA c);

        double get(double x, double y);
        double get(double x, double y, double z);
        double get(double x, double y, double z, double w);
        double get(double x, double y, double z, double w, double u, double v);

        protected:
        CRGBAParameter m_source1, m_source2;
    };
};

#endif
#include "implicitrgbadotproduct.h"

namespace NoiseLibrary
{
    CImplicitRGBADotProduct::CImplicitRGBADotProduct() : CImplicitModuleBase(), m_source1(), m_source2(){}
    CImplicitRGBADotProduct::~CImplicitRGBADotProduct(){}

    void CImplicitRGBADotProduct::setSource1(CRGBAModuleBase * m){m_source1.set(m);}
    void CImplicitRGBADotProduct::setSource1(SRGBA c){m_source1.set(c);}
    void CImplicitRGBADotProduct::setSource2(CRGBAModuleBase * m){m_source2.set(m);}
    void CImplicitRGBADotProduct::setSource2(SRGBA c){m_source2.set(c);}
    double CImplicitRGBADotProduct::get(double x, double y)
    {
        SRGBA s1=m_source1.get(x,y), s2=m_source2.get(x,y);
        return s1[0]*s2[0] + s1[1]*s2[1] + s1[2]*s2[2] + s1[3]*s2[3];
    }
    double CImplicitRGBADotProduct::get(double x, double y, double z)
    {
        SRGBA s1=m_source1.get(x,y,z), s2=m_source2.get(x,y,z);
        return s1[0]*s2[0] + s1[1]*s2[1] + s1[2]*s2[2] + s1[3]*s2[3];
    }
    double CImplicitRGBADotProduct::get(double x, double y, double z, double w)
    {
        SRGBA s1=m_source1.get(x,y,z,w), s2=m_source2.get(x,y,z,w);
        return s1[0]*s2[0] + s1[1]*s2[1] + s1[2]*s2[2] + s1[3]*s2[3];
    }
    double CImplicitRGBADotProduct::get(double x, double y, double z, double w, double u, double v)
    {
        SRGBA s1=m_source1.get(x,y,z,w,u,v), s2=m_source2.get(x,y,z,w,u,v);
        return s1[0]*s2[0] + s1[1]*s2[1] + s1[2]*s2[2] + s1[3]*s2[3];
    }
};
