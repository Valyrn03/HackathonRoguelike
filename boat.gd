extends Node

class_name Boat

@export var speed = 100
@export var durability = 0.5 # out of 1??
@export var upgradeLevel = 0.0;

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass 


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass
	
func upgrade(player: Player):
	if (player.hasTool()):
		self.upgradeLevel += 1
		player.useTool();
		

	
	
