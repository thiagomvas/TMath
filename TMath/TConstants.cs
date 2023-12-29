using System.Numerics;

namespace TMath;

/// <summary>
/// Contains a variety of constants in Mathematics, Physics, Astronomy and some Scientific Notation Prefixes.
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
    /// The value of Euler's Number (e).
    /// </summary>
    /// <remarks>
    /// Euler's Number is a mathematical constant that represents the base of the natural logarithm. 
    /// It is approximately equal to 2.71828 and frequently appears in mathematical and scientific contexts.
    /// </remarks>
    public static readonly T E = T.CreateSaturating(2.71828_18284_59045_23536_02874_714m);

    /// <summary>
    /// The value of 1 / e, the inverse of Euler's Number.
    /// </summary>
    /// <remarks>
    /// The inverse of Euler's Number (1 / e) is approximately equal to 0.36787. 
    /// This constant is often used in exponential decay and other mathematical expressions involving the reciprocal of e.
    /// </remarks>
    public static readonly T InvE = T.CreateSaturating(0.36787_94411_71442_32159_55258_287m);

    /// <summary>
    /// The value of e^2 (e squared), where e is Euler's Number.
    /// </summary>
    /// <remarks>
    /// e^2 is the square of Euler's Number (e), a mathematical constant representing the base of the natural logarithm. 
    /// It is an irrational number and plays a fundamental role in mathematical analysis and applications. The value of e^2 is approximately 7.38905.
    /// </remarks>
    public static readonly T ESquared = T.CreateSaturating(7.38905_60989_30650_22723_04274_606);

    /// <summary>
    /// The square root of Euler's Number (e).
    /// </summary>
    /// <remarks>
    /// The square root of Euler's Number (e) is a mathematical constant denoted as √e. 
    /// It is an irrational number and represents the positive square root of Euler's Number. 
    /// The value of √e is approximately 1.64872 and has applications in various mathematical and scientific contexts.
    /// </remarks>
    public static readonly T SqrtE = T.CreateSaturating(1.64872_12707_00128_14684_86507_878);

    /// <summary>
    /// The value of Pi (π).
    /// </summary>
    /// <remarks>
    /// Pi is a fundamental mathematical constant that represents the ratio of a circle's circumference to its diameter. 
    /// It is approximately equal to 3.14159 and is widely used in geometry and trigonometry.
    /// </remarks>
    public static readonly T Pi = T.CreateSaturating(3.14159_26535_89793_23846_26433_832m);

    /// <summary>
    /// The value of 2 * Pi (2π), also known as tau (τ) .
    /// </summary>
    /// <remarks>
    /// Two times Pi (2π) is approximately equal to 6.28318. 
    /// This constant is often used in calculations involving periodic phenomena, such as waves and oscillations.
    /// </remarks>
    public static readonly T TwoPi = T.CreateSaturating(6.28318_53071_79586_47692_52867_666);

    /// <summary>
    /// The value of Pi^2 (π²).
    /// </summary>
    /// <remarks>
    /// Pi squared (π²) is approximately equal to 9.86960. This constant appears in various mathematical formulas and equations, 
    /// particularly those involving areas and volumes of geometric shapes.
    /// </remarks>
    public static readonly T PiSquared = T.CreateSaturating(9.86960_44010_89358_61883_44909_999);

    /// <summary>
    /// The square root of Pi (π).
    /// </summary>
    /// <remarks>
    /// The square root of Pi (π) is a mathematical constant denoted as √π. It represents the positive square root of the mathematical constant Pi. 
    /// The value of √π is approximately 1.77245 and is involved in various mathematical and scientific calculations, particularly those related to circles and geometry.
    /// </remarks>
    public static readonly T SqrtPi = T.CreateSaturating(1.77245_38509_05516_02729_81674_833);

    /// <summary>
    /// The value of Pi/2 (π/2) representing 90 degrees in radians.
    /// </summary>
    /// <remarks>
    /// Pi over 2 (π/2) is approximately equal to 1.57079. This constant is frequently used in trigonometry and geometry, 
    /// representing a right angle (90 degrees) in radians.
    /// </remarks>
    public static readonly T PiOver2 = T.CreateSaturating(1.57079_63267_94896_61923_13216_916);

    /// <summary>
    /// The value of Pi/3 (π/3) representing 60 degrees in radians.
    /// </summary>
    /// <remarks>
    /// Pi over 3 (π/3) is approximately equal to 1.04719. This constant is frequently used in trigonometry and geometry, 
    /// representing an angle of 60 degrees in radians.
    /// </remarks>
    public static readonly T PiOver3 = T.CreateSaturating(1.04719_75511_96597_74615_42144_611);

    /// <summary>
    /// The value of Pi/4 (π/4) representing 45 degrees in radians.
    /// </summary>
    /// <remarks>
    /// Pi over 4 (π/4) is approximately equal to 0.78539. 
    /// This constant is frequently used in trigonometry and geometry, representing an angle of 45 degrees in radians.
    /// </remarks>
    public static readonly T PiOver4 = T.CreateSaturating(0.78539_81633_97448_30961_56608_458);

    /// <summary>
    /// The value of Pi/6 (π/6) representing 30 degrees in radians.
    /// </summary>
    /// <remarks>
    /// Pi over 6 (π/6) is approximately equal to 0.52359. 
    /// This constant is frequently used in trigonometry and geometry, representing an angle of 30 degrees in radians.
    /// </remarks>
    public static readonly T PiOver6 = T.CreateSaturating(0.52359_87755_98298_87307_71072_305);

    /// <summary>
    /// The value of 1 degree in radians.
    /// </summary>
    /// <remarks>
    /// One degree in radians is approximately equal to 0.01745. 
    /// This constant is used in converting between degrees and radians in trigonometric calculations.
    /// </remarks>
    /// <seealso cref="TFunctions.Rad2Deg{T}(T)"/>
    /// <seealso cref="TFunctions.ToRadians{T}(T)"/>
    public static readonly T Degree = T.CreateSaturating(0.01745_32925_19943_29576_92369_077);

    /// <summary>
    /// The value of the Golden Ratio, a number that satisfies Phi = 1 + 1 / Phi.
    /// </summary>
    /// <remarks>
    /// The Golden Ratio, often denoted by the Greek letter Phi (φ), is a mathematical constant that appears 
    /// in various natural and artistic contexts. It is approximately equal to 1.61803 and possesses unique mathematical properties.
    /// </remarks>
    public static readonly T GoldenRatio = T.CreateSaturating(1.61803_39887_49894_84820_45868_344m);

    /// <summary>
    /// The value of the square root of 2.
    /// </summary>
    /// <remarks>
    /// The square root of 2 (√2) is an irrational number that represents the length of the diagonal of a unit square. 
    /// It is approximately equal to 1.41421 and frequently appears in geometry and mathematical proofs.
    /// </remarks>
    public static readonly T Sqrt2 = T.CreateSaturating(1.41421_35623_73095_04880_16887_242m);

    /// <summary>
    /// The value of the square root of 3.
    /// </summary>
    /// <remarks>
    /// The square root of 3 (√3) is an irrational number that appears in geometry, particularly in the context of equilateral triangles. 
    /// It is approximately equal to 1.73205 and has significance in various mathematical and scientific applications.
    /// </remarks>
    public static readonly T Sqrt3 = T.CreateSaturating(1.73205_08075_68877_29352_74463_415m);

    /// <summary>
    /// The value of the square root of 5.
    /// </summary>
    /// <remarks>
    /// The square root of 5 (√5) is an irrational number that appears in mathematical and geometric contexts. 
    /// It is approximately equal to 2.23606 and is related to the properties of the golden ratio and Fibonacci sequence.
    /// </remarks>
    public static readonly T Sqrt5 = T.CreateSaturating(2.23606_79774_99789_69640_91736_687m);

    /// <summary>
    /// The value of the natural logarithm of 2.
    /// </summary>
    /// <remarks>
    /// The natural logarithm of 2 (ln 2) is a mathematical constant representing the exponent to which the base 'e' 
    /// must be raised to obtain the value 2. It is approximately equal to 0.69314 and is used in various mathematical and computational applications.
    /// </remarks>
    public static readonly T Ln2 = T.CreateSaturating(0.69314_71805_59945_30941_72321_214m);

    /// <summary>
    /// The value of the natural logarithm of 10.
    /// </summary>
    /// <remarks>
    /// The natural logarithm of 10 (ln 10) is a mathematical constant representing the exponent to which the base 'e' must be raised to obtain the value 10. 
    /// It is approximately equal to 2.30258 and is frequently used in logarithmic calculations.
    /// </remarks>
    public static readonly T Ln10 = T.CreateSaturating(2.30258_50929_94045_68401_79914_547m);

    /// <summary>
    /// The Catalan constant.
    /// </summary>
    /// <remarks>
    /// The Catalan constant is a mathematical constant that appears in various combinatorial problems, particularly those involving binary trees and parenthetical expressions. 
    /// It is denoted by the symbol C₀ and is approximately equal to 0.91596.
    /// </remarks>
    public static readonly T Catalan = T.CreateSaturating(0.91596_41589_18919_71425_20638_687m);

    /// <summary>
    /// The Khinchin constant.
    /// </summary>
    /// <remarks>
    /// The Khinchin constant is a real number that arises in number theory, particularly in the study of continued fractions. 
    /// It is denoted by the symbol K and is approximately equal to 2.68545. The constant is named after the Russian mathematician Aleksandr Khinchin.
    /// </remarks>
    public static readonly T Khinchin = T.CreateSaturating(2.68545_44693_00616_72058_27498_289m);

    /// <summary>
    /// The Glaisher constant.
    /// </summary>
    /// <remarks>
    /// The Glaisher constant is a mathematical constant denoted by the symbol A and appears in various mathematical formulas, 
    /// including those involving the Barnes G-function. It is approximately equal to 1.28242.
    /// </remarks>
    public static readonly T Glaisher = T.CreateSaturating(1.28242_71243_78304_49504_88016_845m);

    /// <summary>
    /// Apery's constant.
    /// </summary>
    /// <remarks>
    /// Apery's constant is an irrational number denoted by the symbol ζ(3), where ζ is the Riemann zeta function. 
    /// It plays a significant role in number theory and is approximately equal to 1.20205. The constant is named after the French mathematician Roger Apery.
    /// </remarks>
    public static readonly T Apery = T.CreateSaturating(1.20205_69031_59594_28539_97381_615m);

    /// <summary>
    /// Euler's constant (Euler-Mascheroni constant).
    /// </summary>
    /// <remarks>
    /// Euler's constant, also known as the Euler-Mascheroni constant, is denoted by the symbol γ. 
    /// It is an important mathematical constant in analysis and appears in the study of the gamma function and harmonic series. The constant is approximately equal to 0.57721.
    /// </remarks>
    public static readonly T EulerMascheroni = T.CreateSaturating(0.57721_56649_01532_86060_65120_900m);

    /// <summary>
    /// The Omega constant.
    /// </summary>
    /// <remarks>
    /// The Omega constant is a real number denoted by the symbol Ω. It arises in the study of the Lambert W function, 
    /// a multivalued function related to exponentiation. The constant is approximately equal to 0.56714.
    /// </remarks>
    public static readonly T Omega = T.CreateSaturating(0.56714_39323_73311_12146_51000_000m);

    #endregion

    #region Physics

    /// <summary>
    /// The speed of light in a vacuum.
    /// </summary>
    /// <remarks>
    /// The speed of light is the speed at which electromagnetic waves propagate through a vacuum. It is a fundamental constant and represents 
    /// the maximum speed at which information or matter can travel. The speed of light is approximately 299,792,458 meters per second.
    /// </remarks>
    public static readonly T SpeedOfLight = T.CreateSaturating(299_792_458m);

    /// <summary>
    /// The gravitational constant.
    /// </summary>
    /// <remarks>
    /// The gravitational constant is a constant of proportionality in Newton's law of universal gravitation. 
    /// It describes the gravitational force between two objects with mass. 
    /// The gravitational constant is denoted by the symbol G and is approximately equal to 6.6743 x 10^-11 N·(m/kg)^2.
    /// </remarks>
    public static readonly T GravitationalConstant = T.CreateSaturating(6.6743e-11);

    /// <summary>
    /// The value of Planck's Constant.
    /// </summary>
    /// <remarks>
    /// Planck's constant, symbolized as h, is a fundamental universal constant that defines the quantum nature of energy. 
    /// It relates the energy of a photon to its frequency through the equation E = hν, where E is energy, h is Planck's constant, and ν is frequency. 
    /// The value of Planck's constant is approximately 6.62607015 x 10^-34 J·s.
    /// </remarks>
    public static readonly T PlancksConstant = T.CreateSaturating(6.62607015e-34);

    /// <summary>
    /// The value of the reduced Planck's Constant.
    /// </summary>
    /// <remarks>
    /// The reduced Planck's constant, symbolized as ħ (h-bar), is Planck's constant divided by 2π. 
    /// It often appears in quantum mechanics and is a fundamental constant in the study of particles at the quantum level. 
    /// The value of the reduced Planck's constant is approximately 1.054571817 x 10^-34 J·s.
    /// </remarks>
    public static readonly T DiracConstant = T.CreateSaturating(1.054571817e-34);

    /// <summary>
    /// The elementary charge.
    /// </summary>
    /// <remarks>
    /// Elementary charge is the electric charge carried by a single proton or electron. 
    /// It is a fundamental constant in physics and is denoted by the symbol 'e'. 
    /// The value of the elementary charge is approximately 1.602176634 x 10^-19 coulombs.
    /// </remarks>
    public static readonly T ElementaryCharge = T.CreateSaturating(1.602176634e-19);

    /// <summary>
    /// The mass of an electron.
    /// </summary>
    /// <remarks>
    /// The mass of an electron is the mass of a subatomic particle with a negative elementary electric charge. 
    /// It is a fundamental constant in physics and is approximately 9.1093837015 x 10^-31 kilograms.
    /// </remarks>
    public static readonly T ElectronMass = T.CreateSaturating(9.1093837015e-31);

    /// <summary>
    /// The mass of a proton.
    /// </summary>
    /// <remarks>
    /// The mass of a proton is the mass of a subatomic particle with a positive elementary electric charge. 
    /// It is one of the fundamental particles in the nucleus of an atom. The mass of a proton is approximately 1.67262192369 x 10^-27 kilograms.
    /// </remarks>
    public static readonly T ProtonMass = T.CreateSaturating(1.67262192369e-27);

    /// <summary>
    /// The mass of a neutron.
    /// </summary>
    /// <remarks>
    /// The mass of a neutron is the mass of a subatomic particle with no net electric charge. 
    /// Neutrons, together with protons, constitute the nucleus of an atom. 
    /// The mass of a neutron is approximately 1.67492749804 x 10^-27 kilograms.
    /// </remarks>
    public static readonly T NeutronMass = T.CreateSaturating(1.67492749804e-27);

    /// <summary>
    /// Avogadro's constant.
    /// </summary>
    /// <remarks>
    /// Avogadro's constant is the number of constituent particles (usually atoms or molecules) that are contained in one mole of a given substance. 
    /// It is a fundamental constant in chemistry and is approximately 6.02214076 x 10^23 particles per mole.
    /// </remarks>
    public static readonly T AvogadroConstant = T.CreateSaturating(6.02214076e23);

    /// <summary>
    /// Boltzmann's constant.
    /// </summary>
    /// <remarks>
    /// Boltzmann's constant is a proportionality constant that relates the average kinetic energy of particles in a gas with the temperature of the gas. 
    /// It is denoted by the symbol k and is approximately equal to 1.380649 x 10^-23 J/K.
    /// </remarks>
    public static readonly T BoltzmannConstant = T.CreateSaturating(1.380649e-23);

    /// <summary>
    /// Molar gas constant.
    /// </summary>
    /// <remarks>
    /// The molar gas constant is a physical constant that is the gas constant (R) divided by Avogadro's number. 
    /// It is denoted by the symbol R and is approximately equal to 8.31446261815324 J/(mol·K).
    /// </remarks>
    public static readonly T MolarGasConstant = T.CreateSaturating(8.31446261815324);

    /// <summary>
    /// Stefan-Boltzmann constant.
    /// </summary>
    /// <remarks>
    /// The Stefan-Boltzmann constant is a proportionality constant that describes the power radiated 
    /// per unit surface area of a black body in thermal equilibrium with its surroundings. It is denoted by the symbol σ 
    /// and is approximately equal to 5.670374419 x 10^-8 W/(m^2·K^4).
    /// </remarks>
    public static readonly T StefanBoltzmannConstant = T.CreateSaturating(5.670374419e-8);

    /// <summary>
    /// Faraday's constant.
    /// </summary>
    /// <remarks>
    /// Faraday's constant is the charge per mole of electrons and is used in electrochemistry. 
    /// It is denoted by the symbol F and is approximately equal to 96,485.33212 C/mol.
    /// </remarks>
    public static readonly T FaradayConstant = T.CreateSaturating(96485.33212_33100_184);

    /// <summary>
    /// Vacuum permittivity.
    /// </summary>
    /// <remarks>
    /// Vacuum permittivity is a physical constant that characterizes the ability of a vacuum to permit electric 
    /// field lines to pass through it. It is denoted by the symbol ε₀ and is approximately equal to 8.8541878128 x 10^-12 C^2/(N·m^2).
    /// </remarks>
    public static readonly T VacuumPermittivity = T.CreateSaturating(8.8541878128e-12);

    /// <summary>
    /// Vacuum permeability.
    /// </summary>
    /// <remarks>
    /// Vacuum permeability is a physical constant that describes the magnetic permeability of a vacuum. 
    /// It is denoted by the symbol μ₀ and is approximately equal to 1.25663706212 x 10^-6 T·m/A.
    /// </remarks>
    public static readonly T VacuumPermeability = T.CreateSaturating(1.25663706212e-6);


    #endregion

    #region Astronomical

    /// <summary>
    /// The Astronomical Unit.
    /// </summary>
    /// <remarks>
    /// The Astronomical Unit (AU) is a unit of length used in astronomy to define distances within our solar system. 
    /// It is approximately 149.6 million kilometers, representing the mean distance between the Earth and the Sun.
    /// </remarks>
    public static readonly T AstronomicalUnit = T.CreateSaturating(149_597_870_700m);

    /// <summary>
    /// The Light Year.
    /// </summary>
    /// <remarks>
    /// The Light Year is a unit of astronomical distance, representing the distance that light travels in 
    /// one year in the vacuum of space. It is approximately 9.46 trillion kilometers.
    /// </remarks>
    public static readonly T LightYear = T.CreateSaturating(9_460_730_472_580_800_000m);

    /// <summary>
    /// The Parsec.
    /// </summary>
    /// <remarks>
    /// The Parsec is a unit of astronomical distance, commonly used in astronomy to measure large-scale cosmic structures. 
    /// It is approximately 3.09 quadrillion kilometers, or 3.26 light-years.
    /// </remarks>
    public static readonly T Parsec = T.CreateSaturating(30_856_775_814_671_900_000m);

    /// <summary>
    /// The Solar Mass.
    /// </summary>
    /// <remarks>
    /// The Solar Mass is a unit of mass used in astronomy to express the mass of celestial objects, particularly stars. 
    /// It is approximately equal to the mass of the Sun, which is about 1.98847 × 10^30 kilograms.
    /// </remarks>
    public static readonly T SolarMass = T.CreateSaturating(1.988_47e30);

    /// <summary>
    /// The Earth Mass.
    /// </summary>
    /// <remarks>
    /// The Earth Mass is a unit of mass used in astronomy to compare the mass of other celestial bodies 
    /// to that of the Earth. It is approximately 5.9722 × 10^24 kilograms.
    /// </remarks>
    public static readonly T EarthMass = T.CreateSaturating(5.972_2e24);

    #endregion

    #region Scientific Notation Prefixes

    /// <summary>
    /// The Yotta prefix.
    /// </summary>
    /// <remarks>
    /// Yotta is the SI unit prefix representing a factor of 10^24. It is used to denote extremely large quantities, such as in information storage or energy measurements.
    /// </remarks>
    public static readonly T Yotta = T.CreateSaturating(1e24);

    /// <summary>
    /// The Zetta prefix.
    /// </summary>
    /// <remarks>
    /// Zetta is the SI unit prefix representing a factor of 10^21. It is commonly used in information technology and data storage contexts to indicate large data capacities.
    /// </remarks>
    public static readonly T Zetta = T.CreateSaturating(1e21);

    /// <summary>
    /// The Exa prefix.
    /// </summary>
    /// <remarks>
    /// Exa is the SI unit prefix representing a factor of 10^18. It is used in various scientific and engineering disciplines to denote quantities on the order of 10^18.
    /// </remarks>
    public static readonly T Exa = T.CreateSaturating(1e18);

    /// <summary>
    /// The Peta prefix.
    /// </summary>
    /// <remarks>
    /// Peta is the SI unit prefix representing a factor of 10^15. It is commonly used in information technology and data storage to indicate large data capacities.
    /// </remarks>
    public static readonly T Peta = T.CreateSaturating(1e15);

    /// <summary>
    /// The Tera prefix.
    /// </summary>
    /// <remarks>
    /// Tera is the SI unit prefix representing a factor of 10^12. It is widely used in computing and telecommunications to denote large data capacities and data transfer rates.
    /// </remarks>
    public static readonly T Tera = T.CreateSaturating(1e12);

    /// <summary>
    /// The Giga prefix.
    /// </summary>
    /// <remarks>
    /// Giga is the SI unit prefix representing a factor of 10^9. It is commonly used in computing and electronics to denote large quantities, such as in data storage and processing speeds.
    /// </remarks>
    public static readonly T Giga = T.CreateSaturating(1e9);

    /// <summary>
    /// The Mega prefix.
    /// </summary>
    /// <remarks>
    /// Mega is the SI unit prefix representing a factor of 10^6. It is used in various contexts, including data storage, telecommunications, and digital media capacities.
    /// </remarks>
    public static readonly T Mega = T.CreateSaturating(1e6);

    /// <summary>
    /// The Kilo prefix.
    /// </summary>
    /// <remarks>
    /// Kilo is the SI unit prefix representing a factor of 10^3. It is commonly used to denote quantities such as weight, distance, and data storage capacity.
    /// </remarks>
    public static readonly T Kilo = T.CreateSaturating(1e3);

    /// <summary>
    /// The Hecto prefix.
    /// </summary>
    /// <remarks>
    /// Hecto is the SI unit prefix representing a factor of 10^2. It is less commonly used than other prefixes but is occasionally encountered in some scientific and engineering contexts.
    /// </remarks>
    public static readonly T Hecto = T.CreateSaturating(1e2);

    /// <summary>
    /// The Deca prefix.
    /// </summary>
    /// <remarks>
    /// Deca is the SI unit prefix representing a factor of 10^1. It is rarely used in modern scientific and engineering practices.
    /// </remarks>
    public static readonly T Deca = T.CreateSaturating(1e1);

    /// <summary>
    /// The Deci prefix.
    /// </summary>
    /// <remarks>
    /// Deci is the SI unit prefix representing a factor of 10^-1. It is used in various scientific and engineering contexts, particularly in measurements of volume and length.
    /// </remarks>
    public static readonly T Deci = T.CreateSaturating(1e-1);

    /// <summary>
    /// The Centi prefix.
    /// </summary>
    /// <remarks>
    /// Centi is the SI unit prefix representing a factor of 10^-2. It is commonly used in measurements of length and is equivalent to one hundredth of the base unit.
    /// </remarks>
    public static readonly T Centi = T.CreateSaturating(1e-2);

    /// <summary>
    /// The Milli prefix.
    /// </summary>
    /// <remarks>
    /// Milli is the SI unit prefix representing a factor of 10^-3. It is widely used in measurements of weight, volume, and other quantities.
    /// </remarks>
    public static readonly T Milli = T.CreateSaturating(1e-3);

    /// <summary>
    /// The Micro prefix.
    /// </summary>
    /// <remarks>
    /// Micro is the SI unit prefix representing a factor of 10^-6. It is commonly used in electronics, physics, and biology to denote small quantities.
    /// </remarks>
    public static readonly T Micro = T.CreateSaturating(1e-6);

    /// <summary>
    /// The Nano prefix.
    /// </summary>
    /// <remarks>
    /// Nano is the SI unit prefix representing a factor of 10^-9. It is frequently used in nanotechnology and measurements at the atomic and molecular scale.
    /// </remarks>
    public static readonly T Nano = T.CreateSaturating(1e-9);

    /// <summary>
    /// The Pico prefix.
    /// </summary>
    /// <remarks>
    /// Pico is the SI unit prefix representing a factor of 10^-12. It is commonly used in physics and engineering to denote very small quantities.
    /// </remarks>
    public static readonly T Pico = T.CreateSaturating(1e-12);

    /// <summary>
    /// The Femto prefix.
    /// </summary>
    /// <remarks>
    /// Femto is the SI unit prefix representing a factor of 10^-15. It is used in physics, particularly in the study of subatomic particles and atomic scale measurements.
    /// </remarks>
    public static readonly T Femto = T.CreateSaturating(1e-15);

    /// <summary>
    /// The Atto prefix.
    /// </summary>
    /// <remarks>
    /// Atto is the SI unit prefix representing a factor of 10^-18. It is used in physics and nanotechnology to denote extremely small scales.
    /// </remarks>
    public static readonly T Atto = T.CreateSaturating(1e-18);

    /// <summary>
    /// The Zepto prefix.
    /// </summary>
    /// <remarks>
    /// Zepto is the SI unit prefix representing a factor of 10^-21. It is rarely used in practice but may be encountered in discussions related to extremely small scales.
    /// </remarks>
    public static readonly T Zepto = T.CreateSaturating(1e-21);

    /// <summary>
    /// The Yocto prefix.
    /// </summary>
    /// <remarks>
    /// Yocto is the SI unit prefix representing a factor of 10^-24. It is one of the smallest SI prefixes and is rarely used in practical applications.
    /// </remarks>
    public static readonly T Yocto = T.CreateSaturating(1e-24);


    #endregion
}