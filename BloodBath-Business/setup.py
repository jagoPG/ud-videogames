#!/usr/bin/python
from core.game_manager import GameManager

missions = []


def show_todo_quest(world):
    chapter = world.get_chapter(1)

    print('TODO QUEST')
    for item in chapter.todo_quests.values():
        add_current_missions(item)
        print(item.title + ': ' + item.description)
    print('\n')


def add_current_missions(item):
    global missions
    counter = 0
    while counter < len(missions):
        if missions[counter].uid == item.uid:
            return
        counter += 1
    missions.append(item)


def print_world_status(world):
    print('Latest game: ' + str(world.latest_save))
    print('====================================================================')

    for chapter in world.chapters:
        print('Chapter ' + chapter.title)
        print('Order: ' + str(chapter.order))
        print('Quest list:')

        quests = sorted(chapter.quests.values(), key=lambda quest: quest.order)
        for quest in quests:
            print('\tUid: ' + quest.uid)
            print('\tTitle: ' + quest.title)
            print('\tDescription: ' + quest.description + '\n')


def complete_first_mission(world):
    global missions
    print('Complete first mission')
    world.get_chapter(1).complete_quest(missions[0].uid)
    show_todo_quest(world)
    del missions[0]


def complete_second_third_mission(world):
    global missions
    print('Complete second and third missions')

    counter = 0
    for item in missions:
        world.get_chapter(1).complete_quest(item.uid)
        show_todo_quest(world)
        counter += 1
        if counter == 2:
            return


if __name__ == '__main__':
    game_manager = GameManager()

    # create a new game
    world = game_manager.make_new_game()
    print_world_status(world)

    # only first mission is shown
    show_todo_quest(world)

    # mark first mission as complete
    complete_first_mission(world)

    # mark second and third mission complete
    complete_second_third_mission(world)
