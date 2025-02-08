extends Node2D

@export var amplitude: float = 30.0  # Height of the waves
@export var frequency: float = 4.0  # Number of waves across the width
@export var speed: float = 2.0  # Speed of wave movement
@export var wave_width: int = 1000  # Width of the wave
@export var points_count: int = 50  # Smoothness of the wave
@export var lateral_movement: float = 5.0  # Side-to-side wave motion

var time_passed: float = 0.0
var line: Line2D

func _ready():
	line = Line2D.new()
	line.width = 3
	line.default_color = Color(0, 0.6, 1)  # Light blue color
	add_child(line)
	update_wave()

func _process(delta):
	time_passed += delta * speed
	update_wave()

func update_wave():
	var points = []
	for i in range(points_count + 1):
		var x = (i / float(points_count)) * wave_width
		var wave = sin(x * frequency / wave_width * TAU + time_passed)
		
		# Sharpen wave peaks to be more square
		var square_wave = sign(wave) * pow(abs(wave), 0.5)

		# Add lateral movement (side-to-side motion)
		var lateral_offset = sin(time_passed * 0.8 + x * 0.05) * lateral_movement

		var y = square_wave * amplitude
		points.append(Vector2(x + lateral_offset, y))  # Adjust Y position

	line.points = points
