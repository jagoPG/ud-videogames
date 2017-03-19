#!/usr/bin/python
# -*- coding: utf-8 -*-
import core.model.Quest as q


class Chapter:
    def __init__(self, uid, title, order):
        self.uid = uid
        self.title = title
        self.order = order
        self.quests = {}
        self.todo_quests = {}
        self.quests_completed = {}

    def add_quest(self, quest_id, quest):
        if type(quest) != q.Quest:
            raise q.QuestInvalidTypeException
        self.quests[quest_id] = quest

    def show_todo_quest(self, quest_id):
        self.todo_quests[quest_id] = self.quests[quest_id]
        del self.quests[quest_id]

    def complete_quest(self, quest_id):
        quest = self.todo_quests[quest_id]
        quest.set_quest_completed()
        self.quests_completed.update({quest_id: quest})
        del self.todo_quests[quest_id]

        # unlock new quests
        counter = 0
        quests = list(self.quests.values())
        while counter < len(quests):
            current = quests[counter]
            current.remove_dependency(quest_id)
            if not current.has_any_dependency():
                self.show_todo_quest(current.uid)
            counter += 1


class ChapterInvalidTypeException(Exception):
    pass


class ChapterNotFoundException(Exception):
    pass
