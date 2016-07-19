#ifndef IMPLICIT_CURVE_H
#define IMPLICIT_CURVE_H
#include "implicitmodulebase.h"
#include "implicitbasisfunction.h"
#include "../Imaging/templates/tcurve.h"

#include <vector>
namespace anl
{
    class CImplicitCurve : public CImplicitModuleBase
    {
        public:
        CImplicitCurve();
        CImplicitCurve(ANLFloatType s, int interptype=LINEAR);
        CImplicitCurve(CImplicitModuleBase * s, int interptype=LINEAR);

        ~CImplicitCurve();

        void pushPoint(ANLFloatType t, ANLFloatType v);
        void clearCurve();
        void setSource(ANLFloatType t);
        void setSource(CImplicitModuleBase * m);
        void setInterpType(int type);

        ANLFloatType get(ANLFloatType x, ANLFloatType y);
        ANLFloatType get(ANLFloatType x, ANLFloatType y, ANLFloatType z);
        ANLFloatType get(ANLFloatType x, ANLFloatType y, ANLFloatType z, ANLFloatType w);
        ANLFloatType get(ANLFloatType x, ANLFloatType y, ANLFloatType z, ANLFloatType w, ANLFloatType u, ANLFloatType v);

        protected:
        TCurve<ANLFloatType> m_curve;
        CScalarParameter m_source;
        int m_type;
    };
};

#endif
#include "implicitcurve.h"

namespace anl
{
    CImplicitCurve::CImplicitCurve() : CImplicitModuleBase(), m_source(0.0), m_type(LINEAR){}
    CImplicitCurve::CImplicitCurve(ANLFloatType s, int interptype) : CImplicitModuleBase(), m_source(s), m_type(interptype){}
    CImplicitCurve::CImplicitCurve(CImplicitModuleBase * s, int interptype) : CImplicitModuleBase(), m_source(s), m_type(interptype){}
    CImplicitCurve::~CImplicitCurve(){}

    void CImplicitCurve::pushPoint(ANLFloatType t, ANLFloatType v)
    {
        m_curve.pushPoint(t,v);
    }

    void CImplicitCurve::clearCurve()
    {
        m_curve.clear();
    }

    void CImplicitCurve::setInterpType(int t)
    {
        m_type=t;
        if(m_type<0) m_type=0;
        if(m_type>QUINTIC) m_type=QUINTIC;
    }

    void CImplicitCurve::setSource(ANLFloatType t)
    {
        m_source.set(t);
    }
    void CImplicitCurve::setSource(CImplicitModuleBase * m)
    {
        m_source.set(m);
    }

    ANLFloatType CImplicitCurve::get(ANLFloatType x, ANLFloatType y)
    {
        ANLFloatType t=m_source.get(x,y);
        switch(m_type)
        {
            case NONE: return m_curve.noInterp(t); break;
            case LINEAR: return m_curve.linearInterp(t); break;
            case CUBIC: return m_curve.cubicInterp(t); break;
            case QUINTIC: return m_curve.quinticInterp(t); break;
            default: return m_curve.linearInterp(t); break;
        }
    }

    ANLFloatType CImplicitCurve::get(ANLFloatType x, ANLFloatType y, ANLFloatType z)
    {
        ANLFloatType t=m_source.get(x,y,z);
        switch(m_type)
        {
            case NONE: return m_curve.noInterp(t); break;
            case LINEAR: return m_curve.linearInterp(t); break;
            case CUBIC: return m_curve.cubicInterp(t); break;
            case QUINTIC: return m_curve.quinticInterp(t); break;
            default: return m_curve.linearInterp(t); break;
        }
    }

    ANLFloatType CImplicitCurve::get(ANLFloatType x, ANLFloatType y, ANLFloatType z, ANLFloatType w)
    {
        ANLFloatType t=m_source.get(x,y,z,w);
        switch(m_type)
        {
            case NONE: return m_curve.noInterp(t); break;
            case LINEAR: return m_curve.linearInterp(t); break;
            case CUBIC: return m_curve.cubicInterp(t); break;
            case QUINTIC: return m_curve.quinticInterp(t); break;
            default: return m_curve.linearInterp(t); break;
        }
    }

    ANLFloatType CImplicitCurve::get(ANLFloatType x, ANLFloatType y, ANLFloatType z, ANLFloatType w, ANLFloatType u, ANLFloatType v)
    {
        ANLFloatType t=m_source.get(x,y,z,w,u,v);
        switch(m_type)
        {
            case NONE: return m_curve.noInterp(t); break;
            case LINEAR: return m_curve.linearInterp(t); break;
            case CUBIC: return m_curve.cubicInterp(t); break;
            case QUINTIC: return m_curve.quinticInterp(t); break;
            default: return m_curve.linearInterp(t); break;
        }
    }


};
