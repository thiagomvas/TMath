using System.Numerics;

namespace TMath;

/// <summary>
/// Contains a variety of constants in Mathematics and Physics.
/// </summary>
/// <remarks>
/// Ideally, use <see cref="double"/> when using this class, but it works for any <see cref="INumber{TSelf}"/>,
/// however, be aware of rounding errors.
/// </remarks>
/// <typeparam name="T">The type to pass these constants in</typeparam>
public static class TConstants<T> where T : INumber<T>
{
    #region Mathematics

    /// <summary>
    /// The value of Euler's Number.
    /// </summary>
    public static readonly T E = T.CreateSaturating(2.71828_18284_59045_23536_02874_714m);

    /// <summary>
    /// The value of 1 / e, the inverse of Euler's Number.
    /// </summary>
    public static readonly T InvE = T.CreateSaturating(0.36787_94411_71442_32159_55258_287m);

    /// <summary>
    /// The value of Pi
    /// </summary>
    public static readonly T Pi = T.CreateSaturating(3.14159_26535_89793_23846_26433_832m);

    /// <summary>
    /// The value of 2 * Pi
    /// </summary>
    public static readonly T TwoPi = T.CreateSaturating(6.28318_53071_79586_47692_52867_666);

    /// <summary>
    /// The value of Pi^2
    /// </summary>
    public static readonly T PiSquared = T.CreateSaturating(9.86960_44010_89358_61883_44909_999);

    /// <summary>
    /// The value of Pi/2 (90 degrees in radians)
    /// </summary>
    public static readonly T PiOver2 = T.CreateSaturating(1.57079_63267_94896_61923_13216_916);

    /// <summary>
    /// The value of Pi/3 (60 degrees in radians)
    /// </summary>
    public static readonly T PiOver3 = T.CreateSaturating(1.04719_75511_96597_74615_42144_611);

    /// <summary>
    /// The value of Pi/4 (45 degrees in radians)
    /// </summary>
    public static readonly T PiOver4 = T.CreateSaturating(0.78539_81633_97448_30961_56608_458);

    /// <summary>
    /// The value of Pi/6 (30 degrees in radians)
    /// </summary>
    public static readonly T PiOver6 = T.CreateSaturating(0.52359_87755_98298_87307_71072_305);

    /// <summary>
    /// The value of 1 degree in radians
    /// </summary>
    /// <seealso cref="TFunctions.Rad2Deg{T}(T)"/>
    /// <seealso cref="TFunctions.ToRadians{T}(T)"/>
    public static readonly T Degree = T.CreateSaturating(0.01745_32925_19943_29576_92369_077);

    /// <summary>
    /// The value of the Golden Ratio, a number that satisfies Phi = 1 + 1 / Phi.
    /// </summary>
    public static readonly T GoldenRatio = T.CreateSaturating(1.61803_39887_49894_84820_45868_344m);

    /// <summary>
    /// The value of the square root of 2.
    /// </summary>
    public static readonly T Sqrt2 = T.CreateSaturating(1.41421_35623_73095_04880_16887_242m);

    /// <summary>
    /// The value of the square root of 3.
    /// </summary>
    public static readonly T Sqrt3 = T.CreateSaturating(1.73205_08075_68877_29352_74463_415m);

    /// <summary>
    /// The value of the square root of 5.
    /// </summary>
    public static readonly T Sqrt5 = T.CreateSaturating(2.23606_79774_99789_69640_91736_687m);

    /// <summary>
    /// The value of the natural logarithm of 2.
    /// </summary>
    public static readonly T Ln2 = T.CreateSaturating(0.69314_71805_59945_30941_72321_214m);

    /// <summary>
    /// The value of the natural logarithm of 10.
    /// </summary>
    public static readonly T Ln10 = T.CreateSaturating(2.30258_50929_94045_68401_79914_547m);

    /// <summary>
    /// The Catalan constant.
    /// </summary>
    /// <remarks>
    /// The Catalan constant appears in various combinatorial problems, particularly those involving binary trees and parenthetical expressions.
    /// </remarks>
    public static readonly T Catalan = T.CreateSaturating(0.91596_41589_18919_71425_20638_687m);

    /// <summary>
    /// The Khinchin constant.
    /// </summary>
    /// <remarks>
    /// The Khinchin constant arises in number theory, particularly in the study of continued fractions.
    /// </remarks>
    public static readonly T Khinchin = T.CreateSaturating(2.68545_44693_00616_72058_27498_289m);

    /// <summary>
    /// The Glaisher constant.
    /// </summary>
    /// <remarks>
    /// The Glaisher constant appears in various mathematical formulas, including those involving the Barnes G-function.
    /// </remarks>
    public static readonly T Glaisher = T.CreateSaturating(1.28242_71243_78304_49504_88016_845m);

    /// <summary>
    /// Apery's constant.
    /// </summary>
    /// <remarks>
    /// Apery's constant is an irrational number that appears in the field of number theory, particularly in the study of the Riemann zeta function.
    /// </remarks>
    public static readonly T Apery = T.CreateSaturating(1.20205_69031_59594_28539_97381_615m);

    /// <summary>
    /// Euler's constant (Euler-Mascheroni constant).
    /// </summary>
    /// <remarks>
    /// Euler's constant, also known as the Euler-Mascheroni constant, is an important mathematical constant in analysis. It appears in the study of the gamma function and harmonic series.
    /// </remarks>
    public static readonly T EulerMascheroni = T.CreateSaturating(0.57721_56649_01532_86060_65120_900m);

    /// <summary>
    /// The Omega constant.
    /// </summary>
    /// <remarks>
    /// The Omega constant is a real number that arises in the study of the Lambert W function, a multivalued function related to exponentiation.
    /// </remarks>
    public static readonly T Omega = T.CreateSaturating(0.56714_39323_73311_12146_51000_000m);


    #endregion 

    #region Physics

    /// <summary>
    /// The speed of light in a vacuum.
    /// </summary>
    /// <remarks>Speed at which electromagnetic waves propagate through a vacuum. It is a fundamental constant and the maximum speed at which information or matter can travel.</remarks>
    public static readonly T SpeedOfLight = T.CreateSaturating(299_792_458m);

    /// <summary>
    /// The gravitational constant.
    /// </summary>
    /// <remarks>Constant of proportionality in Newton's law of universal gravitation, describing the gravitational force between two objects with mass.</remarks>
    public static readonly T GravitationalConstant = T.CreateSaturating(6.6743e-11);


    /// <summary>
    /// The value of Planck's Constant.
    /// </summary>
    /// <remarks>Planck's constant, symbolized as h, is a fundamental universal constant that defines the quantum nature of energy and relates the energy of a photon to its frequency.</remarks>
    public static readonly T PlancksConstant = T.CreateSaturating(6.62607015e-34);

    /// <summary>
    /// The value of the reduced Planck's Constant.
    /// </summary>
    /// <remarks>Planck's constant divided by 2 pi.</remarks>
    public static readonly T DiracConstant = T.CreateSaturating(1.054571817e-34);

    /// <summary>
    /// The elementary charge.
    /// </summary>
    /// <remarks>Elementary charge is the electric charge carried by a single proton or electron.</remarks>
    public static readonly T ElementaryCharge = T.CreateSaturating(1.602176634e-19);

    /// <summary>
    /// The mass of an electron.
    /// </summary>
    /// <remarks>Mass of an electron, a subatomic particle with a negative elementary electric charge.</remarks>
    public static readonly T ElectronMass = T.CreateSaturating(9.1093837015e-31);

    /// <summary>
    /// The mass of a proton.
    /// </summary>
    /// <remarks>Mass of a proton, a subatomic particle with a positive elementary electric charge.</remarks>
    public static readonly T ProtonMass = T.CreateSaturating(1.67262192369e-27);

    /// <summary>
    /// The mass of a neutron.
    /// </summary>
    /// <remarks>Mass of a neutron, a subatomic particle with no net electric charge.</remarks>
    public static readonly T NeutronMass = T.CreateSaturating(1.67492749804e-27);

    /// <summary>
    /// Avogadro's constant.
    /// </summary>
    /// <remarks>Number of constituent particles (usually atoms or molecules) that are contained in one mole of a given substance.</remarks>
    public static readonly T AvogadroConstant = T.CreateSaturating(6.02214076e23);

    /// <summary>
    /// Boltzmann's constant.
    /// </summary>
    /// <remarks>Proportionality constant that relates the average kinetic energy of particles in a gas with the temperature of the gas.</remarks>
    public static readonly T BoltzmannConstant = T.CreateSaturating(1.380649e-23);

    /// <summary>
    /// Molar gas constant.
    /// </summary>
    /// <remarks>Physical constant that is the gas constant divided by Avogadro's number.</remarks>
    public static readonly T MolarGasConstant = T.CreateSaturating(8.31446261815324);

    /// <summary>
    /// Stefan-Boltzmann constant.
    /// </summary>
    /// <remarks>Proportionality constant that describes the power radiated per unit surface area of a black body in thermal equilibrium with its surroundings.</remarks>
    public static readonly T StefanBoltzmannConstant = T.CreateSaturating(5.670374419e-8);

    /// <summary>
    /// Faraday's constant.
    /// </summary>
    /// <remarks>Charge per mole of electrons, used in electrochemistry.</remarks>
    public static readonly T FaradayConstant = T.CreateSaturating(96485.33212_33100_184);

    /// <summary>
    /// Vacuum permittivity.
    /// </summary>
    /// <remarks>Physical constant that characterizes the ability of a vacuum to permit electric field lines to pass through it.</remarks>
    public static readonly T VacuumPermittivity = T.CreateSaturating(8.8541878128e-12);

    /// <summary>
    /// Vacuum permeability.
    /// </summary>
    /// <remarks>Physical constant that describes the magnetic permeability of a vacuum.</remarks>
    public static readonly T VacuumPermeability = T.CreateSaturating(1.25663706212e-6);

    #endregion

    #region Astronomical

    /// <summary>
    /// The Astronomical Unit.
    /// </summary>
    /// <remarks>
    /// The Astronomical Unit (AU) is a unit of length used in astronomy to define distances within our solar system. It is approximately 149.6 million kilometers, representing the mean distance between the Earth and the Sun.
    /// </remarks>
    public static readonly T AstronomicalUnit = T.CreateSaturating(149_597_870_700m);

    /// <summary>
    /// The Light Year.
    /// </summary>
    /// <remarks>
    /// The Light Year is a unit of astronomical distance, representing the distance that light travels in one year in the vacuum of space. It is approximately 9.46 trillion kilometers.
    /// </remarks>
    public static readonly T LightYear = T.CreateSaturating(9_460_730_472_580_800_000m);

    /// <summary>
    /// The Parsec.
    /// </summary>
    /// <remarks>
    /// The Parsec is a unit of astronomical distance, commonly used in astronomy to measure large-scale cosmic structures. It is approximately 3.09 quadrillion kilometers, or 3.26 light-years.
    /// </remarks>
    public static readonly T Parsec = T.CreateSaturating(30_856_775_814_671_900_000m);

    /// <summary>
    /// The Solar Mass.
    /// </summary>
    /// <remarks>
    /// The Solar Mass is a unit of mass used in astronomy to express the mass of celestial objects, particularly stars. It is approximately equal to the mass of the Sun, which is about 1.98847 × 10^30 kilograms.
    /// </remarks>
    public static readonly T SolarMass = T.CreateSaturating(1.988_47e30);

    /// <summary>
    /// The Earth Mass.
    /// </summary>
    /// <remarks>
    /// The Earth Mass is a unit of mass used in astronomy to compare the mass of other celestial bodies to that of the Earth. It is approximately 5.9722 × 10^24 kilograms.
    /// </remarks>
    public static readonly T EarthMass = T.CreateSaturating(5.972_2e24);

    #endregion
}