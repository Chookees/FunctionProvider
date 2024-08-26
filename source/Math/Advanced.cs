namespace FunctionProvider.Math
{
    using SM = System.Math;

    public sealed class Advanced
    {
        #region Lazy initialization

        private static readonly Lazy<Advanced> lazy = new Lazy<Advanced>(() => new Advanced());

        public static Advanced Task { get { return lazy.Value; } }

        private Advanced() { }

        #endregion

        #region Tangent calculation

        /// <summary>
        /// Calculates the equation of the tangent line to a function at a specific point.
        /// Example usage: var (slope, intercept) = Tangent(f, x);
        /// </summary>
        /// <param name="f">The function for which the tangent line is calculated.</param>
        /// <param name="x">The point at which the tangent line is calculated.</param>
        /// <returns>Returns the slope m and y-intercept b as a tuple.</returns>
        public (double slope, double intercept) Tangent(Func<double, double> f, double x)
        {
            // Calculate the function value at the point x
            double y = f(x);

            // Calculate the slope of the tangent line using the derivative
            double m = DerivativeForTangent(f, x);

            // Calculate the y-intercept of the tangent line
            double b = y - m * x;

            // Return the slope and y-intercept as a tuple
            return (m, b);
        }

        /// <summary>
        /// Calculates the derivative of a function at a specific point.
        /// </summary>
        /// <param name="f">The function for which the derivative is calculated.</param>
        /// <param name="x">The point at which the derivative is calculated.</param>
        /// <param name="h">A small increment used to approximate the derivative (default is (1 \times 10^{-10}))</param>
        /// <returns>The approximate value of the derivative at point x.</returns>
        private double DerivativeForTangent(Func<double, double> f, double x, double h = 1e-10)
        {
            return (f(x + h) - f(x)) / h;
        }

        #endregion

        #region Heat Equation

        /// <summary>
        /// Solves the heat equation using the finite difference method.
        /// Example usage: double[,] result = SolveHeatEquation(u, alpha, dt, dx, timeSteps);
        /// </summary>
        /// <param name="u">Initial state of the grid.</param>
        /// <param name="alpha">Thermal diffusivity constant.</param>
        /// <param name="dt">Time step size.</param>
        /// <param name="dx">Spatial step size.</param>
        /// <param name="timeSteps">Number of time steps to simulate.</param>
        /// <returns>Final state of the grid after the specified number of time steps.</returns>
        public double[,] SolveHeatEquation(double[,] u, double alpha, double dt, double dx, int timeSteps)
        {
            int nx = u.GetLength(0);
            int ny = u.GetLength(1);

            for (int t = 0; t < timeSteps; t++)
            {
                double[,] uNew = new double[nx, ny];

                for (int i = 1; i < nx - 1; i++)
                {
                    for (int j = 1; j < ny - 1; j++)
                    {
                        uNew[i, j] = u[i, j] + alpha * dt / (dx * dx) * (u[i + 1, j] - 2 * u[i, j] + u[i - 1, j])
                                                 + alpha * dt / (dx * dx) * (u[i, j + 1] - 2 * u[i, j] + u[i, j - 1]);
                    }
                }

                u = uNew;
            }

            return u;
        }

        #endregion

        #region Torsion calculation

        /// <summary>
        /// Calculates the torsion of a 3D curve at a given parameter t.
        /// </summary>
        /// <param name="x">Function representing x(t).</param>
        /// <param name="y">Function representing y(t).</param>
        /// <param name="z">Function representing z(t).</param>
        /// <param name="t">Parameter value at which to calculate the torsion.</param>
        /// <returns>Torsion at the given parameter t.</returns>
        public double CalculateTorsion(Func<double, double> x, Func<double, double> y, Func<double, double> z, double t)
        {
            double dx = DerivativeTorsion(x, t);
            double dy = DerivativeTorsion(y, t);
            double dz = DerivativeTorsion(z, t);
            double ddx = SecondDerivativeTorsion(x, t);
            double ddy = SecondDerivativeTorsion(y, t);
            double ddz = SecondDerivativeTorsion(z, t);
            double dddx = ThirdDerivativeTorsion(x, t);
            double dddy = ThirdDerivativeTorsion(y, t);
            double dddz = ThirdDerivativeTorsion(z, t);

            double numerator = (dx * (ddy * dddz - ddz * dddy) - dy * (ddx * dddz - ddz * dddx) + dz * (ddx * dddy - ddy * dddx));
            double denominator = SM.Pow(dx * dx + dy * dy + dz * dz, 1.5);

            return numerator / denominator;
        }

        private double DerivativeTorsion(Func<double, double> f, double t, double h = 1e-5)
        {
            return (f(t + h) - f(t - h)) / (2 * h);
        }

        private double SecondDerivativeTorsion(Func<double, double> f, double t, double h = 1e-5)
        {
            return (f(t + h) - 2 * f(t) + f(t - h)) / (h * h);
        }

        private double ThirdDerivativeTorsion(Func<double, double> f, double t, double h = 1e-5)
        {
            return (f(t + 2 * h) - 2 * f(t + h) + 2 * f(t - h) - f(t - 2 * h)) / (2 * h * h * h);
        }

        #endregion

        #region Curvature calculation

        /// <summary>
        /// Calculates the curvature of a 2D curve at a given parameter t.
        /// </summary>
        /// <param name="x">Function representing x(t).</param>
        /// <param name="y">Function representing y(t).</param>
        /// <param name="t">Parameter value at which to calculate the curvature.</param>
        /// <returns>Curvature at the given parameter t.</returns>
        public double CalculateCurvature(Func<double, double> x, Func<double, double> y, double t)
        {
            double dx = DerivativeCurvature(x, t);
            double dy = DerivativeCurvature(y, t);
            double ddx = SecondDerivativeCurvature(x, t);
            double ddy = SecondDerivativeCurvature(y, t);

            double numerator = SM.Abs(dx * ddy - dy * ddx);
            double denominator = SM.Pow(dx * dx + dy * dy, 1.5);

            return numerator / denominator;
        }

        private double DerivativeCurvature(Func<double, double> f, double t, double h = 1e-5)
        {
            return (f(t + h) - f(t - h)) / (2 * h);
        }

        private double SecondDerivativeCurvature(Func<double, double> f, double t, double h = 1e-5)
        {
            return (f(t + h) - 2 * f(t) + f(t - h)) / (h * h);
        }

        #endregion

        #region 2D-Wave equation

        /// <summary>
        /// Solves the 2D wave equation using the finite difference method.
        /// </summary>
        /// <param name="u">Initial displacement matrix.</param>
        /// <param name="v">Initial velocity matrix.</param>
        /// <param name="c">Wave speed.</param>
        /// <param name="dt">Time step size.</param>
        /// <param name="dx">Spatial step size.</param>
        /// <param name="timeSteps">Number of time steps to simulate.</param>
        /// <returns>The displacement matrix after the specified number of time steps.</returns>
        public double[,] SolveWaveEquation(double[,] u, double[,] v, double c, double dt, double dx, int timeSteps)
        {
            int nx = u.GetLength(0);
            int ny = u.GetLength(1);
            double[,] uPrev = (double[,])u.Clone();
            double[,] uNext = new double[nx, ny];

            for (int t = 0; t < timeSteps; t++)
            {
                for (int i = 1; i < nx - 1; i++)
                {
                    for (int j = 1; j < ny - 1; j++)
                    {
                        double laplacian = (u[i + 1, j] - 2 * u[i, j] + u[i - 1, j]) / (dx * dx)
                                         + (u[i, j + 1] - 2 * u[i, j] + u[i, j - 1]) / (dx * dx);

                        uNext[i, j] = 2 * u[i, j] - uPrev[i, j] + (c * c * dt * dt) * laplacian;
                    }
                }

                // Update previous and current displacement matrices
                uPrev = (double[,])u.Clone();
                u = (double[,])uNext.Clone();
            }

            return u;
        }

        #endregion

        #region Matrix multiplication

        /// <summary>
        /// Multiplies two matrices A and B.
        /// </summary>
        /// <param name="matrixA">The first matrix A.</param>
        /// <param name="matrixB">The second matrix B.</param>
        /// <returns>The resulting matrix after multiplication.</returns>
        /// <exception cref="ArgumentException">Thrown when the number of columns in matrix A does not equal the number of rows in matrix B.</exception>
        public static double[,] MatrixMultiplication(double[,] matrixA, double[,] matrixB)
        {
            int rowsA = matrixA.GetLength(0);
            int columnsA = matrixA.GetLength(1);
            int rowsB = matrixB.GetLength(0);
            int columnsB = matrixB.GetLength(1);

            if (columnsA != rowsB)
            {
                throw new ArgumentException("The number of columns in matrix A must equal the number of rows in matrix B.");
            }

            double[,] resultMatrix = new double[rowsA, columnsB];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < columnsB; j++)
                {
                    resultMatrix[i, j] = 0;
                    for (int k = 0; k < columnsA; k++)
                    {
                        resultMatrix[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return resultMatrix;
        }

        #endregion

        #region SolveQuadraticEquation()

        /// <summary>
        /// Solves a quadratic equation of the form ax^2 + bx + c = 0.
        /// </summary>
        /// <param name="coefficientA">The coefficient a.</param>
        /// <param name="coefficientB">The coefficient b.</param>
        /// <param name="constantC">The constant term c.</param>
        /// <returns>A tuple containing the two solutions (x1, x2). If there are no real solutions, both values will be null.</returns>
        public static (double? x1, double? x2) SolveQuadraticEquation(double coefficientA, double coefficientB, double constantC)
        {
            double discriminant = coefficientB * coefficientB - 4 * coefficientA * constantC;

            if (discriminant < 0)
            {
                // No real solutions
                return (null, null);
            }
            else if (discriminant == 0)
            {
                // One double solution
                double x = -coefficientB / (2 * coefficientA);
                return (x, x);
            }
            else
            {
                // Two distinct solutions
                double sqrtDiscriminant = Math.Sqrt(discriminant);
                double x1 = (-coefficientB + sqrtDiscriminant) / (2 * coefficientA);
                double x2 = (-coefficientB - sqrtDiscriminant) / (2 * coefficientA);
                return (x1, x2);
            }
        }

        #endregion
    }
}
