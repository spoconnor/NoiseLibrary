#ifndef IMPLICIT_SAWTOOTH_H
#define IMPLICIT_SAWTOOTH_H
#include "implicitmodulebase.h"

namespace NoiseLibrary
{
class CImplicitSawtooth : public CImplicitModuleBase
{
    public:
    CImplicitSawtooth();
    CImplicitSawtooth(double source, double period);
    CImplicitSawtooth(double source, CImplicitModuleBase * period);
    CImplicitSawtooth(CImplicitModuleBase * source, double period);
    CImplicitSawtooth(CImplicitModuleBase * source, CImplicitModuleBase * period);
    ~CImplicitSawtooth();

    void setSource(CImplicitModuleBase * s);
    void setSource(double s);
    void setPeriod(CImplicitModuleBase * p);
    void setPeriod(double p);

    double get(double x, double y);
    double get(double x, double y, double z);
    double get(double x, double y, double z, double w);
    double get(double x, double y, double z, double w, double u, double v);

    protected:
    CScalarParameter m_source;
    CScalarParameter m_period;

};
};
#endif
#include "implicitsawtooth.h"
#include <cmath>
namespace NoiseLibrary
{
    CImplicitSawtooth::CImplicitSawtooth() : CImplicitModuleBase(), m_source(0.0), m_period(0.0){}
    CImplicitSawtooth::CImplicitSawtooth(double source, double period) : CImplicitModuleBase(), m_source(source), m_period(period){}
    CImplicitSawtooth::CImplicitSawtooth(double source, CImplicitModuleBase * period) : CImplicitModuleBase(), m_source(source), m_period(period){}
    CImplicitSawtooth::CImplicitSawtooth(CImplicitModuleBase * source, double period) : CImplicitModuleBase(), m_source(source), m_period(period){}
    CImplicitSawtooth::CImplicitSawtooth(CImplicitModuleBase * source, CImplicitModuleBase * period) : CImplicitModuleBase(), m_source(source), m_period(period){}
CImplicitSawtooth::~CImplicitSawtooth()
{
}

void CImplicitSawtooth::setSource(CImplicitModuleBase * s)
{
    m_source.set(s);
}

void CImplicitSawtooth::setSource(double s)
{
    m_source.set(s);
}

void CImplicitSawtooth::setPeriod(CImplicitModuleBase * p)
{
    m_period.set(p);
}

void CImplicitSawtooth::setPeriod(double p)
{
    m_period.set(p);
}

double CImplicitSawtooth::get(double x, double y)
{
    double val=m_source.get(x,y);
    double p=m_period.get(x,y);

    return 2.0*(val/p - floor(0.5 + val/p));
}

double CImplicitSawtooth::get(double x, double y, double z)
{
    double val=m_source.get(x,y,z);
    double p=m_period.get(x,y,z);

    return 2.0*(val/p - floor(0.5 + val/p));
}

double CImplicitSawtooth::get(double x, double y, double z, double w)
{
    double val=m_source.get(x,y,z,w);
    double p=m_period.get(x,y,z,w);

    return 2.0*(val/p - floor(0.5 + val/p));
}

double CImplicitSawtooth::get(double x, double y, double z, double w, double u, double v)
{
    double val=m_source.get(x,y,z,w,u,v);
    double p=m_period.get(x,y,z,w,u,v);

    return 2.0*(val/p - floor(0.5 + val/p));
}
};
