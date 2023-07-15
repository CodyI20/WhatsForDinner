using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GXPEngine.Core;

namespace GXPEngine.Physics
{
	//------------------------------------------------------------------------------------------------------------------------
	//														PhysicsObject
	//------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// A class disgined to apply physics on
	/// </summary>
	public abstract class PhysicsObject : GameObject
	{
		public Vec2 position;
		public Vec2 vecRotation;
		public Vec2 velocity;
		public Vec2 acceleration;
		public float _bounciness = 0.0f;
		public bool trigger = false;

		public virtual bool moving
		{
			get { return velocity.length > 0; }
		}
		public Vec2 oldPosition
		{
			get { return position - velocity; }
		}
		public bool affectedByGravity;

		public int width
		{
			get { return _width; }
		}
		public int height
		{
			get { return _height; }
		}
		protected EasyDraw draw
		{
			get { return _easyDraw; }
		}
		protected Scene _currentScene
		{
			get { return game.Currentscene; }
		}

		protected int _width;
		protected int _height;
		private EasyDraw _easyDraw;

		public PhysicsObject(int pWidth, int pHeight, Vec2 pPosition) : base(false)
		{
			position = pPosition;
			vecRotation = Vec2.GetUnitVectorDeg(0);

			if (pWidth <= 0 || pHeight <= 0)
			{
				throw new Exception("Dimensions of a Physicsobject cannot be smaller or equal to 0");
			}
			else
			{
				_width = pWidth;
				_height = pHeight;
			}

			UpdateScreenPosition();
		}

		protected abstract void Draw();

		public void SetColor(Color fillColor)
		{
			if (_easyDraw == null)
			{
				_easyDraw = new EasyDraw(width + 10, height, false);
				_easyDraw.SetOrigin(_easyDraw.width / 2, _easyDraw.height / 2);

				AddChild(_easyDraw);
			}

			_easyDraw.Clear(Color.Transparent);
			_easyDraw.Fill(fillColor);
			_easyDraw.Stroke(fillColor);
			_easyDraw.StrokeWeight(1);

			Draw();
		}

		protected virtual void UpdateScreenPosition()
		{
			x = position.x;
			y = position.y;
			rotation = vecRotation.angleDeg;
		}

		public bool Colliding(PhysicsObject other)
		{
			bool outp;

			if (other == this)
			{
				return false;
			}
			else if (other is PhysicsPolygon)
			{
				outp = Colliding((PhysicsPolygon)other);
			}
			else if (other is PhysicsLine)
			{
				outp = Colliding((PhysicsLine)other);
			}
			else if (other is PhysicsCircle)
			{
				outp = Colliding((PhysicsCircle)other);
			}
			else
			{
				return false;
			}

			if (outp)
			{
				other.Collide(this);

				if (!other.trigger)
				{
					 Collide(other);
				}
			}

			return outp;
		}

		public abstract bool Colliding(PhysicsLine lineSegment);
		public abstract bool Colliding(PhysicsCircle circle);
		public virtual bool Colliding(PhysicsPolygon poly)
		{
			foreach (PhysicsObject line in poly.lines)
			{
				if (Colliding(line))
				{
					return true;
				}
			}

			return false;
		}
		public abstract void Collide(PhysicsObject other);

		public virtual void Step()
		{
			UpdateScreenPosition();
			setAccelleration();
			applyAcceleration();
			applyVelocity();
		}

        public virtual void Update()
		{
			Step();
		}

		protected virtual void applyVelocity()
		{
			position += velocity * (1f / game.currentFps);
			//Console.WriteLine(1f / game.currentFps);
		}

		protected virtual void applyAcceleration()
		{
			velocity += acceleration * (1f / game.currentFps);
			acceleration.SetXY(0, 0);
		}

		protected virtual void setAccelleration()
		{
			if (affectedByGravity && _currentScene is Level)
			{
				acceleration += ((Level)_currentScene).gravity;
			}
		}
	}
}
