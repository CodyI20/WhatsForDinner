using System;

namespace GXPEngine.Core
{
	public struct Vec2
	{
		public float x;
		public float y;
		
		public Vec2 (float x, float y)
		{
			this.x = x;
			this.y = y;
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														ToString()
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Returns the class as a string
		/// </summary>
		override public string ToString() {
			return "[Vector2 " + x + ", " + y + "]";
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														length
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Returns the length of the current vector or sets the length by normalizing itself and multiplying itself by the value
		/// </summary>
		public float length
		{
			get
			{
				return Mathf.Sqrt((x * x) + (y * y));     //Using pythagoras to calculate the length of the vector
			}

			set
			{
				Normalize();        //First normalizing the vector so its length is 1
				this *= value;      //Multiplying the normalized vector times the given value so the length is now equal to the given value
			}
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														Normalize()
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Normalizes the current vector
		/// </summary>
		public void Normalize()
		{
			this = Normalized();
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														Normalized()
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Returns a normalized version of the current vector without modifying it
		/// </summary>
		public Vec2 Normalized()
		{
			float pX = 0;
			float pY = 0;      

			if (length != 0f)
			{
				pX = x/length;        //Calculate the normalized X value
				pY = y/length;        //Calculate the normalized Y value
			}

			return new Vec2(pX, pY);       //Create a new vector with the normalized X and Y value
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														SetXY()
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Sets the x & y of the current vector to the given two floats
		/// </summary>
		public void SetXY(float pX, float pY)
		{
			x = pX;
			y = pY;
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														Distance()
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Calculates the distance between 2 vectors.
		/// </summary>
		/// <param name='a'>
		/// The first vector
		/// </param>
		/// <param name='b'>
		/// The second vector
		/// </param>
		public static float Distance(Vec2 a, Vec2 b)
		{
			float areaC = Mathf.Pow(b.x - a.x, 2) + Mathf.Pow(b.y - a.y, 2);
			return Mathf.Sqrt(areaC); //Using pythagoras to calculate the distance between two vctors.
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														DirectionBetween()
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Returns a vector from A to B.
		/// </summary>
		/// <param name='a'>
		/// The first vector
		/// </param>
		/// <param name='b'>
		/// The second vector
		/// </param>
		public static Vec2 DirectionBetween(Vec2 a, Vec2 b)
		{
			return b - a;
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														LinInt()
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Performs a linear interpolation between two vectors based on the given weighting and returns the result.
		/// </summary>
		/// <param name='left'>
		/// The first vector
		/// </param>
		/// <param name='right'>
		/// The second vector
		/// </param>
		/// <param name='interpolator'>
		/// This number specificifies the percentage of the second(right) vector in the result (If this is 0f: The left vector will be returned. If this is 1f: the right one. If 0.5f it is an average between the two)
		/// </param>
		public static Vec2 LinInt(Vec2 left, Vec2 right, float interpolator)
		{
			return left + interpolator * (right - left);
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														Deg2Rad()
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Converts the given degrees to radians
		/// </summary>
		/// <param name='degree'>
		/// The input degree value
		/// </param>
		public static float Deg2Rad(float degree)
		{
			return (Mathf.PI / 180) * degree;
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														Rad2Deg()
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Converts the given radians to degrees
		/// </summary>	
		/// <param name='radians'>
		/// The input radians value
		/// </param>
		public static float Rad2Deg(float radians)
		{
			return (180 / Mathf.PI) * radians;
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														RadAngleBetween()
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Returns the angle from the vector from vector A to B in radians
		/// </summary>
		/// <param name='a'>
		/// The first vector
		/// </param>
		/// <param name='b'>
		/// The second vector
		/// </param>
		public static float RadAngleBetween(Vec2 a, Vec2 b)
		{
			return DirectionBetween(a, b).angleRad;
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														DegAngleBetween()
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Returns the angle from the vector from vector A to B in degrees
		/// </summary>
		/// <param name='a'>
		/// The first vector
		/// </param>
		/// <param name='b'>
		/// The second vector
		/// </param>
		public static float DegAngleBetween(Vec2 a, Vec2 b)
		{
			return Rad2Deg(DirectionBetween(a, b).angleRad);
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														GetUnitVectorDeg ()
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Returns a new vector pointing in the given direction in degrees
		/// </summary>
		public static Vec2 GetUnitVectorDeg(float degrees)
		{
			return GetUnitVectorRad(Deg2Rad(degrees));
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														GetUnitVectorRad ()
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Returns a new vector pointing in the given direction in radians
		/// </summary>
		public static Vec2 GetUnitVectorRad(float radians)
		{
            return new Vec2(Mathf.Cos(radians), Mathf.Sin(radians));
        }

		//------------------------------------------------------------------------------------------------------------------------
		//														angleRad
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Sets/Gets the angle of vector in radians without changing its length
		/// </summary>
		public float angleRad
		{
			get { return Mathf.Atan2(y, x); }
			set
			{
				Vec2 temp = Vec2.GetUnitVectorRad(value);
				temp.length = length;

				this = temp; 
			}
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														angleDeg
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Sets/Gets the angle of vector in degrees without changing its length
		/// </summary>
		public float angleDeg
		{
			get { return Rad2Deg(angleRad); }
			set { angleRad = Deg2Rad(value); }
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														RotateDegrees ()
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Rotate the vector over the given angle in degrees
		/// </summary>
		public void RotateDegrees(float degrees)
		{
			RotateRadians(Deg2Rad(degrees));
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														RotateRadians ()
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Rotate the vector over the given angle in radians
		/// </summary>
		public void RotateRadians(float radians)
		{
			float pX = x * Mathf.Cos(radians) - y * Mathf.Sin(radians);
			float pY = x * Mathf.Sin(radians) + y * Mathf.Cos(radians);

			this = new Vec2(pX, pY);
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														RotateAroundDegrees ()
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Rotate the vector around the given point over the given angle in degrees
		/// </summary>
		public void RotateAroundDegrees(float degrees, Vec2 around)
		{
			RotateAroundRadians(Deg2Rad(degrees), around);
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														RotateAroundRadians ()
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Rotate the vector around the given point over the given angle in radians
		/// </summary>
		public void RotateAroundRadians(float radians, Vec2 around)
		{
			this -= around;
			RotateRadians(radians);
			this += around;
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														normalizeDeg ()
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// The entered degree value is normalized, the returend value cannot be outside (-180, 180) degrees
		/// </summary>
		public static float normalizeDeg(float degree)
		{
			if (degree > 180)
			{
				degree -= 360;
			}
			else if (degree < -180)
			{
				degree += 360;
			}

			return degree;
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														RotateTowardsDegrees()
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// The vector will rotate towards the target degrees in given steps
		/// </summary>
		/// <param name='targetDegrees'>
		/// The target degrees for the vector to eventually point too
		/// </param>
		/// <param name='stepDegrees'>
		/// The amount of degrees the vector can turn each time it is called
		/// </param>
		public void RotateTowardsDegrees(float targetDegrees, float stepDegrees)
		{
			if (stepDegrees < 0)
			{
				throw new Exception("Can not rotate in negative steps");
			}

			float diffrence = targetDegrees - angleDeg;

			diffrence = normalizeDeg(diffrence);

			if (Mathf.Abs(diffrence) <= stepDegrees)
			{
				angleDeg = targetDegrees;
			}
			else if (diffrence < 0)
			{
				angleDeg -= stepDegrees;
			}
			else if (diffrence > 0)
			{
				angleDeg += stepDegrees;
			}
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														Dot()
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Will calculate the dot product of a given vector and itself
		/// </summary>
		public float Dot(Vec2 other)
		{
			return x * other.x + y * other.y; ;
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														VectorDotProduct()
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Will calculate the dot product of two given vectors
		/// </summary>
		public static float VectorDotProduct(Vec2 a, Vec2 b)
		{
			return a.Dot(b);
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														Normal()
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Returns a normal to this vector
		/// </summary>
		public Vec2 Normal()
		{
			Vec2 NormalVec = new Vec2(-y, x);
			return NormalVec.Normalized();
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														Reflect()
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Reflects the vector of another vector based on that other vector's normal
		/// </summary>
		public void Reflect(Vec2 pNormal, float pBounciness = 1f)
		{
			this -= (1 + pBounciness) * (this.Dot(pNormal) * pNormal);
		}

        //------------------------------------------------------------------------------------------------------------------------
        //														Boost()
        //------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Takes the current vector and it applies a boost to it according to <paramref name="boostAmount"/>
        /// </summary>
        /// <param name="boostAmount"></param>
        public Vec2 Boost(float boostAmount, float angle = 0, float timeWithBoost = 1f)
        {
            // Convert the angle to radians
            float angleInRadians = Deg2Rad(angle);

            // Calculate the boost vector using the specified angle
            float x = Mathf.Cos(angleInRadians) * boostAmount;
            float y = Mathf.Sin(angleInRadians) * boostAmount;
            Vec2 boostVector = new Vec2(x, y);

            // Add the boost vector to the current vector
            this += boostVector;

			// Return the velocity to its original values
			UndoBoost(boostAmount, timeWithBoost);
			Console.WriteLine("BOOST: "+length);

            return this;
        }
        //------------------------------------------------------------------------------------------------------------------------
        //														Boost()
        //------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Returns the vector to its values before the boost was applied
		/// </summary>
		/// <param name="boostAmount"></param>
        void UndoBoost(float boostAmount, float timeWithBoost = 1f)
        {
            Timer timer = new Timer(timeWithBoost);
            if (timer.done)
            {
                Vec2 normalVelo = Normalized() / boostAmount;
                this = normalVelo;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        //														+ operator
        //------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Returns the result of adding two vectors(without modifying either of them)
        /// </summary>
        public static Vec2 operator +(Vec2 left, Vec2 right)
		{
			return new Vec2(left.x + right.x, left.y + right.y);
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														- operator
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Returns the result of subtracting two vectors(without modifying either of them)
		/// </summary>
		public static Vec2 operator -(Vec2 left, Vec2 right)
		{
			return new Vec2(left.x - right.x, left.y - right.y);
		}

		public static Vec2 operator -(Vec2 right)
		{
			return new Vec2(-right.x, -right.y);
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														* operator
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Returns the result of multiplying a vector by a float(without modifying either of them)
		/// </summary>
		public static Vec2 operator *(Vec2 left, float right)
		{
			return new Vec2(left.x * right, left.y * right);
		}
		public static Vec2 operator *(float left, Vec2 right)
		{
			return right * left;
		}

		//------------------------------------------------------------------------------------------------------------------------
		//														/ operator
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Returns the result of deviding a vector by a float(without modifying either of them)
		/// </summary>
		public static Vec2 operator /(Vec2 left, float right)
		{
			return new Vec2(left.x / right, left.y / right);
		}
	}
}

