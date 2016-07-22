#ifndef IMPLICIT_EXTRACTRGBACHANNEL_H
#define IMPLICIT_EXTRACTRGBACHANNEL_H
#include "implicitmodulebase.h"
#include "rgbamodulebase.h"

namespace NoiseLibrary
{
    enum EExtractChannel
    {
        RED,
        GREEN,
        BLUE,
        ALPHA
    };

    class CImplicitExtractRGBAChannel : public CImplicitModuleBase
    {
        public:
        CImplicitExtractRGBAChannel();
        CImplicitExtractRGBAChannel(int channel);

        void setSource(CRGBAModuleBase * m);
        void setSource(SRGBA c);

        void setChannel(int channel);

        double get(double x, double y);
        double get(double x, double y, double z);
        double get(double x, double y, double z, double w);
        double get(double x, double y, double z, double w, double u, double v);

        protected:
        CRGBAParameter m_source;
        int m_channel;
    };
};

#endif
#include "implicitextractrgbachannel.h"

namespace NoiseLibrary
{
    CImplicitExtractRGBAChannel::CImplicitExtractRGBAChannel() : CImplicitModuleBase(), m_source(SRGBA(0,0,0,0)), m_channel(RED){}
    CImplicitExtractRGBAChannel::CImplicitExtractRGBAChannel(int channel) : CImplicitModuleBase(), m_source(SRGBA(0,0,0,0)), m_channel(channel){}

    void CImplicitExtractRGBAChannel::setSource(CRGBAModuleBase * m)
    {
        m_source.set(m);
    }
    void CImplicitExtractRGBAChannel::setSource(SRGBA c)
    {
        m_source.set(c);
    }
    void CImplicitExtractRGBAChannel::setChannel(int channel)
    {
        m_channel=channel;
        if(channel<RED) channel=RED;
        if(channel>ALPHA) channel=ALPHA;
    }
    double CImplicitExtractRGBAChannel::get(double x, double y)
    {
        SRGBA s=m_source.get(x,y);

        return s[m_channel];
    }

    double CImplicitExtractRGBAChannel::get(double x, double y, double z)
    {
        SRGBA s=m_source.get(x,y,z);

        return s[m_channel];
    }
    double CImplicitExtractRGBAChannel::get(double x, double y, double z, double w)
    {
        SRGBA s=m_source.get(x,y,z,w);

        return s[m_channel];
    }
    double CImplicitExtractRGBAChannel::get(double x, double y, double z, double w, double u, double v)
    {
        SRGBA s=m_source.get(x,y,z,w,u,v);

        return s[m_channel];
    }
};
