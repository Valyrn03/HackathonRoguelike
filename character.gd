extends CharacterBody2D  # Use KinematicBody2D in Godot 3

class_name Player

@export var speed: float = 400.0  # Move speed
@export var gravity: float = 500.0  # Gravity force
@export var jump_force: float = 300.0  # Jump strength
@export var tools: Array = []

var playerAnimation : AnimatedSprite2D

func _ready():
	playerAnimation = $AnimatedSprite2D
	playerAnimation.play("idle")


func _physics_process(delta):
	var direction = Vector2.ZERO
	# Apply gravity if not on the floor
	if not is_on_floor():
		velocity.y += gravity * delta

	# Handle movement
	if Input.is_action_pressed("move_left"):
		direction.x -= 1
		# Play the "move_left" animation
		playerAnimation.play("walk")
		# Flip sprite if moving left (optional)
		playerAnimation.flip_h = true
	elif Input.is_action_pressed("move_right"):
		direction.x += 1
		# Play the "move_right" animation
		playerAnimation.play("walk")
		# Unflip sprite if moving right
		playerAnimation.flip_h = false
	else:
		# Play the "idle" animation when not moving
		playerAnimation.play("idle")

	
	direction = direction.normalized()
	velocity.x = direction.x * speed  # Apply horizontal movement

	# Jumping
	if Input.is_action_just_pressed("move_up") and is_on_floor():
		velocity.y = -jump_force  # Jump upwards

	move_and_slide()  # Apply movement and collision

func pickUpTool(tool):
	self.tools.append(tool)
	
func hasTool() -> bool:
	return !self.tools.is_empty()
	
func useTool():
	self.tools.pop_front()
