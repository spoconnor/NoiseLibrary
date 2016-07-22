using System;

namespace NoiseLibrary
{
    /*
    Given angle r in radians and unit vector u = ai + bj + ck or [a,b,c]', define:

    q0 = cos(r/2),  q1 = sin(r/2) a,  q2 = sin(r/2) b,  q3 = sin(r/2) c

    and construct from these values the rotation matrix:

         (q0² + q1² - q2² - q3²)      2(q1q2 - q0q3)          2(q1q3 + q0q2)

    Q  =      2(q2q1 + q0q3)     (q0² - q1² + q2² - q3²)      2(q2q3 - q0q1)

              2(q3q1 - q0q2)          2(q3q2 + q0q1)     (q0² - q1² - q2² + q3²)

    Multiplication by Q then effects the desired rotation, and in particular:

    Q u = u
    */

    class CImplicitRotateDomain : CImplicitModuleBase
    {

        private double[,] m_rotmatrix = new double[3, 3];
        private CScalarParameter m_ax, m_ay, m_az, m_angledeg;
        private CScalarParameter m_source;


        public CImplicitRotateDomain(double src, double ax, double ay, double az, double angle_deg) : base()
        { m_ax=new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src);}
        public CImplicitRotateDomain(double src, double ax, double ay, double az, CImplicitModuleBase angle_deg) :        base()
        { m_ax=new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src); }
        public CImplicitRotateDomain(double src, double ax, double ay, CImplicitModuleBase az, double angle_deg) :        base()
        { m_ax=new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src); }
        public CImplicitRotateDomain(double src, double ax, double ay, CImplicitModuleBase az, CImplicitModuleBase angle_deg) :        base()
        { m_ax=new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src); }
        public CImplicitRotateDomain(double src, double ax, CImplicitModuleBase ay, double az, double angle_deg) : base()
        { m_ax=new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src); }
        public CImplicitRotateDomain(double src, double ax, CImplicitModuleBase ay, double az, CImplicitModuleBase angle_deg) :        base()
        { m_ax =new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src); }
        public CImplicitRotateDomain(double src, double ax, CImplicitModuleBase ay, CImplicitModuleBase az, double angle_deg) :        base()
        { m_ax=new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src); }
        public CImplicitRotateDomain(double src, double ax, CImplicitModuleBase ay, CImplicitModuleBase az, CImplicitModuleBase angle_deg) :        base()
        { m_ax =new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src);        } 
        public CImplicitRotateDomain(double src, CImplicitModuleBase ax, double ay, double az, double angle_deg) :        base()
        { m_ax =new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src);        } 
        public CImplicitRotateDomain(double src, CImplicitModuleBase ax, double ay, double az, CImplicitModuleBase angle_deg) :        base()
        { m_ax=new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src);        } 
        public CImplicitRotateDomain(double src, CImplicitModuleBase ax, double ay, CImplicitModuleBase az, double angle_deg) :        base()
        { m_ax =new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src);        }
        public CImplicitRotateDomain(double src, CImplicitModuleBase ax, double ay, CImplicitModuleBase az, CImplicitModuleBase angle_deg) :  base()
        { m_ax =new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src);        }
        public CImplicitRotateDomain(double src, CImplicitModuleBase ax, CImplicitModuleBase ay, double az, double angle_deg) : base()
        { m_ax=new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src); }
        public CImplicitRotateDomain(double src, CImplicitModuleBase ax, CImplicitModuleBase ay, double az, CImplicitModuleBase angle_deg) : base()
        { m_ax=new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src); }
        public CImplicitRotateDomain(double src, CImplicitModuleBase ax, CImplicitModuleBase ay, CImplicitModuleBase az, double angle_deg) : base()
        { m_ax=new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src); }
        public CImplicitRotateDomain(double src, CImplicitModuleBase ax, CImplicitModuleBase ay, CImplicitModuleBase az, CImplicitModuleBase angle_deg) : base()
        { m_ax=new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src); }
        public CImplicitRotateDomain(CImplicitModuleBase src, double ax, double ay, double az, double angle_deg) : base()
        { m_ax=new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src); }
        public CImplicitRotateDomain(CImplicitModuleBase src, double ax, double ay, double az, CImplicitModuleBase angle_deg) : base()
        { m_ax=new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src); }
        public CImplicitRotateDomain(CImplicitModuleBase src, double ax, double ay, CImplicitModuleBase az, double angle_deg) : base()
        { m_ax=new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src); }
        public CImplicitRotateDomain(CImplicitModuleBase src, double ax, double ay, CImplicitModuleBase az, CImplicitModuleBase angle_deg) : base()
        { m_ax=new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src); }
        public CImplicitRotateDomain(CImplicitModuleBase src, double ax, CImplicitModuleBase ay, double az, double angle_deg) : base()
        { m_ax=new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src); }
        public CImplicitRotateDomain(CImplicitModuleBase src, double ax, CImplicitModuleBase ay, double az, CImplicitModuleBase angle_deg) : base()
        { m_ax=new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src); }
        public CImplicitRotateDomain(CImplicitModuleBase src, double ax, CImplicitModuleBase ay, CImplicitModuleBase az, double angle_deg) : base()
        { m_ax=new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src); }
        public CImplicitRotateDomain(CImplicitModuleBase src, double ax, CImplicitModuleBase ay, CImplicitModuleBase az, CImplicitModuleBase angle_deg) : base()
        { m_ax=new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src); }
        public CImplicitRotateDomain(CImplicitModuleBase src, CImplicitModuleBase ax, double ay, double az, double angle_deg) : base()
        { m_ax=new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src); }
        public CImplicitRotateDomain(CImplicitModuleBase src, CImplicitModuleBase ax, double ay, double az, CImplicitModuleBase angle_deg) : base()
        { m_ax=new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src); }
        public CImplicitRotateDomain(CImplicitModuleBase src, CImplicitModuleBase ax, double ay, CImplicitModuleBase az, double angle_deg) : base()
        { m_ax=new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src); }
        public CImplicitRotateDomain(CImplicitModuleBase src, CImplicitModuleBase ax, double ay, CImplicitModuleBase az, CImplicitModuleBase angle_deg) : base()
        { m_ax=new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src); }
        public CImplicitRotateDomain(CImplicitModuleBase src, CImplicitModuleBase ax, CImplicitModuleBase ay, double az, double angle_deg) : base()
        { m_ax=new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src); }
        public CImplicitRotateDomain(CImplicitModuleBase src, CImplicitModuleBase ax, CImplicitModuleBase ay, double az, CImplicitModuleBase angle_deg) : base()
        { m_ax=new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src); }
        public CImplicitRotateDomain(CImplicitModuleBase src, CImplicitModuleBase ax, CImplicitModuleBase ay, CImplicitModuleBase az, double angle_deg) : base()
        { m_ax=new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src); }
        public CImplicitRotateDomain(CImplicitModuleBase src, CImplicitModuleBase ax, CImplicitModuleBase ay, CImplicitModuleBase az, CImplicitModuleBase angle_deg) : base()
        { m_ax=new CScalarParameter(ax);  m_ay=new CScalarParameter(ay);  m_az=new CScalarParameter(az);  m_angledeg=new CScalarParameter(angle_deg); m_source=new CScalarParameter(src); }

        private void setSource(CImplicitModuleBase m) { m_source.set(m); }
        private void setSource(double v) { m_source.set(v); }

        private void calculateRotMatrix(double x, double y)
        {
            double angle = m_angledeg.get(x, y) * 360.0 * 3.14159265 / 180.0;
            double ax = m_ax.get(x, y);
            double ay = m_ay.get(x, y);
            double az = m_az.get(x, y);

            double cosangle = Math.Cos(angle);
            double sinangle = Math.Sin(angle);

            m_rotmatrix[0,0] = 1.0 + (1.0 - cosangle) * (ax * ax - 1.0);
            m_rotmatrix[1,0] = -az * sinangle + (1.0 - cosangle) * ax * ay;
            m_rotmatrix[2,0] = ay * sinangle + (1.0 - cosangle) * ax * az;

            m_rotmatrix[0,1] = az * sinangle + (1.0 - cosangle) * ax * ay;
            m_rotmatrix[1,1] = 1.0 + (1.0 - cosangle) * (ay * ay - 1.0);
            m_rotmatrix[2,1] = -ax * sinangle + (1.0 - cosangle) * ay * az;

            m_rotmatrix[0,2] = -ay * sinangle + (1.0 - cosangle) * ax * az;
            m_rotmatrix[1,2] = ax * sinangle + (1.0 - cosangle) * ay * az;
            m_rotmatrix[2,2] = 1.0 + (1.0 - cosangle) * (az * az - 1.0);
        }

        private void calculateRotMatrix(double x, double y, double z)
        {
            double angle = m_angledeg.get(x, y, z) * 360.0 * 3.14159265 / 180.0;
            double ax = m_ax.get(x, y, z);
            double ay = m_ay.get(x, y, z);
            double az = m_az.get(x, y, z);

            double cosangle = Math.Cos(angle);
            double sinangle = Math.Sin(angle);

            m_rotmatrix[0,0] = 1.0 + (1.0 - cosangle) * (ax * ax - 1.0);
            m_rotmatrix[1,0] = -az * sinangle + (1.0 - cosangle) * ax * ay;
            m_rotmatrix[2,0] = ay * sinangle + (1.0 - cosangle) * ax * az;

            m_rotmatrix[0,1] = az * sinangle + (1.0 - cosangle) * ax * ay;
            m_rotmatrix[1,1] = 1.0 + (1.0 - cosangle) * (ay * ay - 1.0);
            m_rotmatrix[2,1] = -ax * sinangle + (1.0 - cosangle) * ay * az;

            m_rotmatrix[0,2] = -ay * sinangle + (1.0 - cosangle) * ax * az;
            m_rotmatrix[1,2] = ax * sinangle + (1.0 - cosangle) * ay * az;
            m_rotmatrix[2,2] = 1.0 + (1.0 - cosangle) * (az * az - 1.0);
        }
        private void calculateRotMatrix(double x, double y, double z, double w)
        {
            double angle = m_angledeg.get(x, y, z, w) * 360.0 * 3.14159265 / 180.0;
            double ax = m_ax.get(x, y, z, w);
            double ay = m_ay.get(x, y, z, w);
            double az = m_az.get(x, y, z, w);

            double cosangle = Math.Cos(angle);
            double sinangle = Math.Sin(angle);

            m_rotmatrix[0,0] = 1.0 + (1.0 - cosangle) * (ax * ax - 1.0);
            m_rotmatrix[1,0] = -az * sinangle + (1.0 - cosangle) * ax * ay;
            m_rotmatrix[2,0] = ay * sinangle + (1.0 - cosangle) * ax * az;

            m_rotmatrix[0,1] = az * sinangle + (1.0 - cosangle) * ax * ay;
            m_rotmatrix[1,1] = 1.0 + (1.0 - cosangle) * (ay * ay - 1.0);
            m_rotmatrix[2,1] = -ax * sinangle + (1.0 - cosangle) * ay * az;

            m_rotmatrix[0,2] = -ay * sinangle + (1.0 - cosangle) * ax * az;
            m_rotmatrix[1,2] = ax * sinangle + (1.0 - cosangle) * ay * az;
            m_rotmatrix[2,2] = 1.0 + (1.0 - cosangle) * (az * az - 1.0);
        }
        private void calculateRotMatrix(double x, double y, double z, double w, double u, double v)
        {
            double angle = m_angledeg.get(x, y, z, w, u, v) * 360.0 * 3.14159265 / 180.0;
            double ax = m_ax.get(x, y, z, w, u, v);
            double ay = m_ay.get(x, y, z, w, u, v);
            double az = m_az.get(x, y, z, w, u, v);

            double cosangle = Math.Cos(angle);
            double sinangle = Math.Sin(angle);

            m_rotmatrix[0,0] = 1.0 + (1.0 - cosangle) * (ax * ax - 1.0);
            m_rotmatrix[1,0] = -az * sinangle + (1.0 - cosangle) * ax * ay;
            m_rotmatrix[2,0] = ay * sinangle + (1.0 - cosangle) * ax * az;

            m_rotmatrix[0,1] = az * sinangle + (1.0 - cosangle) * ax * ay;
            m_rotmatrix[1,1] = 1.0 + (1.0 - cosangle) * (ay * ay - 1.0);
            m_rotmatrix[2,1] = -ax * sinangle + (1.0 - cosangle) * ay * az;

            m_rotmatrix[0,2] = -ay * sinangle + (1.0 - cosangle) * ax * az;
            m_rotmatrix[1,2] = ax * sinangle + (1.0 - cosangle) * ay * az;
            m_rotmatrix[2,2] = 1.0 + (1.0 - cosangle) * (az * az - 1.0);
        }
        private void setAxis(double ax, double ay, double az)
        {
            m_ax.set(ax);
            m_ay.set(ay);
            m_az.set(az);
        }

        private void setAxis(CImplicitModuleBase ax, CImplicitModuleBase ay, CImplicitModuleBase az)
        {
            m_ax.set(ax);
            m_ay.set(ay);
            m_az.set(az);
        }
        private void setAxisX(double ax)
        {
            m_ax.set(ax);
        }
        private void setAxisY(double ay)
        {
            m_ay.set(ay);
        }
        private void setAxisZ(double az)
        {
            m_az.set(az);
        }
        private void setAxisX(CImplicitModuleBase ax)
        {
            m_ax.set(ax);
        }
        private void setAxisY(CImplicitModuleBase ay)
        {
            m_ay.set(ay);
        }
        private void setAxisZ(CImplicitModuleBase az)
        {
            m_az.set(az);
        }

        private void setAngle(double a)
        {
            m_angledeg.set(a);
        }
        private void setAngle(CImplicitModuleBase a)
        {
            m_angledeg.set(a);
        }

        public override double get(double x, double y)
        {
            double nx, ny;
            double angle = m_angledeg.get(x, y) * 360.0 * 3.14159265 / 180.0;
            double cos2d = Math.Cos(angle);
            double sin2d = Math.Sin(angle);
            nx = x * cos2d - y * sin2d;
            ny = y * cos2d + x * sin2d;
            return m_source.get(nx, ny);
        }

        public override double get(double x, double y, double z)
        {
            calculateRotMatrix(x, y, z);
            double nx, ny, nz;
            nx = (m_rotmatrix[0,0] * x) + (m_rotmatrix[1,0] * y) + (m_rotmatrix[2,0] * z);
            ny = (m_rotmatrix[0,1] * x) + (m_rotmatrix[1,1] * y) + (m_rotmatrix[2,1] * z);
            nz = (m_rotmatrix[0,2] * x) + (m_rotmatrix[1,2] * y) + (m_rotmatrix[2,2] * z);
            return m_source.get(nx, ny, nz);
        }
        public override double get(double x, double y, double z, double w)
        {

            calculateRotMatrix(x, y, z, w);
            double nx, ny, nz;
            nx = (m_rotmatrix[0,0] * x) + (m_rotmatrix[1,0] * y) + (m_rotmatrix[2,0] * z);
            ny = (m_rotmatrix[0,1] * x) + (m_rotmatrix[1,1] * y) + (m_rotmatrix[2,1] * z);
            nz = (m_rotmatrix[0,2] * x) + (m_rotmatrix[1,2] * y) + (m_rotmatrix[2,2] * z);
            return m_source.get(nx, ny, nz, w);
        }
        public override double get(double x, double y, double z, double w, double u, double v)
        {

            calculateRotMatrix(x, y, z, w, u, v);
            double nx, ny, nz;
            nx = (m_rotmatrix[0,0] * x) + (m_rotmatrix[1,0] * y) + (m_rotmatrix[2,0] * z);
            ny = (m_rotmatrix[0,1] * x) + (m_rotmatrix[1,1] * y) + (m_rotmatrix[2,1] * z);
            nz = (m_rotmatrix[0,2] * x) + (m_rotmatrix[1,2] * y) + (m_rotmatrix[2,2] * z);
            return m_source.get(nx, ny, nz, w, u, v);
        }
    }
}
