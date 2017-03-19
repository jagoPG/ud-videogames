#!/usr/bin/python
# -*- coding: utf-8 -*-

from xml.dom import minidom
from core.model.World import World
from core.model.Chapter import Chapter
from core.model.Quest import Quest


class GameManager:
    MAX_WORLDS = 3

    def __init__(self):
        self.worlds = {}

    def make_new_game(self):
        number_worlds = len(self.worlds)
        if number_worlds == 3:
            raise WorldNumberExceedException
        world = World()
        chapter = load_chapter(1)
        chapter.quests.get(1)
        world.add_chapter(chapter)
        world.save_game()
        self.worlds.update({number_worlds: world})

        return world


def load_new_chapter(self, world, number):
    chapter = load_chapter(number)
    world.add_chapter(self, chapter)

    return chapter


def load_chapter(number):
    """
    Load a new chapter with all new missions
    :param number:
    :return:
    """
    current = None
    xmldoc = minidom.parse('./data/quests.xml')
    chapters = xmldoc.getElementsByTagName('chapters')[0].getElementsByTagName('chapter')

    for chapter in chapters:
        if str(chapter.getAttribute('order')) == str(number):
            current = Chapter(
                chapter.getAttribute('uid'),
                chapter.getAttribute('title'),
                int(chapter.getAttribute('order'))
            )
            for item in chapter.getElementsByTagName('quest'):
                quest = Quest(
                    item.getAttribute('uid'),
                    item.getAttribute('title'),
                    item.getAttribute('description'),
                    int(item.getAttribute('order')),
                    False,
                    False,
                    False
                )
                dependencies = item.getAttribute('depends')
                if dependencies is not None:
                    resolve_quest_dependency(quest, dependencies)
                current.add_quest(quest.uid, quest)
                if quest.order == 1:
                    current.show_todo_quest(quest.uid)
    return current


def resolve_quest_dependency(quest, dependencies):
    if ',' in dependencies:
        for dependency in dependencies.split(','):
            quest.add_dependency(dependency)
    else:
        quest.add_dependency(dependencies)



class WorldNumberExceedException(Exception):
    pass
